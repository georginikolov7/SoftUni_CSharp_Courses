namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Boardgames.Data;
    using Boardgames.Data.Models;
    using Boardgames.Data.Models.Enums;
    using Boardgames.DataProcessor.ImportDto;
    using Boardgames.Utilities;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            const string Root = "Creators";

            StringBuilder output = new();

            XmlHelper helper = new XmlHelper();
            CreatorImportDto[] importDtos = helper.Deserialize<CreatorImportDto[]>(xmlString, Root);

            List<Creator> creatorsToImport = new();
            foreach (var importDto in importDtos)
            {
                if (!IsValid(importDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }
                Creator creatorToImport = new Creator()
                {
                    FirstName = importDto.FirstName,
                    LastName = importDto.LastName,
                };
                List<Boardgame> boardGamesToImport = new();

                foreach (var boardGameDto in importDto.Boardgames)
                {
                    if (!IsValid(boardGameDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    Boardgame boardgame = new Boardgame()
                    {
                        Name = boardGameDto.Name,
                        Rating = boardGameDto.Rating,
                        YearPublished = boardGameDto.YearPublished,
                        CategoryType = (CategoryType)boardGameDto.CategoryType,
                        Mechanics = boardGameDto.Mechanics
                    };
                    boardGamesToImport.Add(boardgame);
                }

                creatorToImport.Boardgames = boardGamesToImport;
                creatorsToImport.Add(creatorToImport);

                output.AppendLine(String.Format(SuccessfullyImportedCreator, creatorToImport.FirstName, creatorToImport.LastName, creatorToImport.Boardgames.Count));
            }

            context.Creators.AddRange(creatorsToImport);
            context.SaveChanges();

            return output.ToString().Trim();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            SellerImportDto[]? dtos = JsonConvert.DeserializeObject<SellerImportDto[]>(jsonString);

            StringBuilder output = new();

            List<int> validBoardgameIds = context.Boardgames
                .Select(b => b.Id)
                .ToList();

            List<Seller> sellersToImport = new();
            foreach(var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Seller sellerToImport = new()
                {
                    Name = dto.Name,
                    Address = dto.Address,
                    Country = dto.Country,
                    Website = dto.Website
                };

                List<BoardgameSeller> boardgamesSellers = new();
                foreach(int id in dto.Boardgames.Distinct())
                {
                    if (!validBoardgameIds.Contains(id))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }
                    boardgamesSellers.Add(new BoardgameSeller()
                    {
                        Seller = sellerToImport,
                        BoardgameId = id
                    });
                }
                sellerToImport.BoardgamesSellers = boardgamesSellers;

                sellersToImport.Add(sellerToImport);
                output.AppendLine(String.Format(SuccessfullyImportedSeller, sellerToImport.Name, sellerToImport.BoardgamesSellers.Count));
            }

            context.Sellers.AddRange(sellersToImport);
            context.SaveChanges();

            return output.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
