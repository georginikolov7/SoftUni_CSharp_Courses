function formatGrade(grade) {
    let gradeString;
    let failed = false;
    if (grade < 3) {
        gradeString = "Fail";
        failed = true;
    } else if (grade < 3.50) {
        gradeString = "Poor";
    } else if (grade < 4.50) {
        gradeString = "Good";
    } else if (grade < 5.50) {
        gradeString = "Very good";
    } else {
        gradeString = "Excellent";
    }

    if (failed) {
        return `Fail (2)`;
    } else {
        return `${gradeString} (${grade.toFixed(2)})`;
    }
}