namespace P10_SoftUniCoursePlanning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> courses = Console.ReadLine()
                .Split(", ")
                .ToList();
            string input;
            while ((input = Console.ReadLine()) != "course start")
            {
                string[] arguments = input.Split(":").ToArray();
                string lessonTitle = arguments[1];
                switch (arguments[0])
                {
                    case "Add":
                        AddLessonToCourse(courses, lessonTitle);
                        break;
                    case "Insert":
                        InsertLesson(courses, lessonTitle, int.Parse(arguments[2]));
                        break;
                    case "Remove":
                        RemoveLesson(courses, lessonTitle);
                        break;
                    case "Swap":
                        string secondLessonTitle = arguments[2];
                        SwapLessons(courses, lessonTitle, secondLessonTitle);
                        
                        break;
                    case "Exercise":
                        AddExercise(courses, lessonTitle);
                        break;
                }

            }
            foreach(string course in courses)
            {
                Console.WriteLine($"{courses.IndexOf(course)+1}.{course}");
            }
        }


        static void AddLessonToCourse(List<string> courses, string lessonTitle)
        {
            if (!CheckIfLessonExists(courses, lessonTitle))
            {
                courses.Add(lessonTitle);
            }
        }
        static void InsertLesson(List<string> courses, string lessonTitle, int index)
        {
            if (!CheckIfLessonExists(courses, lessonTitle))
            {
                courses.Insert(index, lessonTitle);
            }
        }
        static void RemoveLesson(List<string> courses, string lessonTitle)
        {
            if (CheckIfLessonExists(courses, lessonTitle))
            {
                courses.Remove(lessonTitle);
                RemoveExercise(courses, $"{lessonTitle}-Exercise");
            }
        }
        static void SwapLessons(List<string> courses, string lesson1, string lesson2)
        {
            if (CheckIfLessonExists(courses, lesson1) && CheckIfLessonExists(courses, lesson2))
            {
                (courses[courses.IndexOf(lesson1)], courses[courses.IndexOf(lesson2)]) = (courses[courses.IndexOf(lesson2)], courses[courses.IndexOf(lesson1)]);
                SwapExercises(courses, $"{lesson1}-Exercise",lesson1);
                SwapExercises(courses, $"{lesson2}-Exercise", lesson2);
            }
        }
        static void AddExercise(List<string> courses, string lessonTitle)
        {
            if (!CheckIfLessonExists(courses, lessonTitle))
            {
                AddLessonToCourse(courses, lessonTitle);
            }

            if (!courses.Contains($"{lessonTitle}-Exercise"))
            {
                courses.Insert(courses.IndexOf(lessonTitle) + 1, $"{lessonTitle}-Exercise");
            }

        }

        static void RemoveExercise(List<string> courses, string exercise)
        {
            if (CheckIfExerciseExists(courses, exercise))
            {
                courses.Remove(exercise);
            }
        }
        static void SwapExercises(List<string> courses, string exercise, string lessonTitle)
        {
            if (CheckIfExerciseExists(courses,exercise))
            {
                courses.Remove(exercise);
                courses.Insert(courses.IndexOf(lessonTitle) + 1, exercise);
            }

            

        }

        static bool CheckIfLessonExists(List<string> courses, string lessonTitle)
        {
            return courses.Contains(lessonTitle);
        }

        static bool CheckIfExerciseExists(List<string> courses, string exercise1)
        {
            return courses.Contains(exercise1);
        }

    }
}