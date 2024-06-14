document.addEventListener("DOMContentLoaded", function() {
    const professions = [
        "Accountant",
        "Actor/Actress",
        "Architect",
        "Artist",
        "Attorney/Lawyer",
        "Chef",
        "Civil Engineer",
        "Dentist",
        "Doctor/Physician",
        "Electrician",
        "Graphic Designer",
        "Journalist",
        "Mechanical Engineer",
        "Musician",
        "Nurse",
        "Pharmacist",
        "Photographer",
        "Police Officer",
        "Programmer/Software Developer",
        "Psychologist",
        "Real Estate Agent",
        "Teacher/Educator",
        "Veterinarian",
        "Web Designer",
        "Writer/Author"
    ];

    function populateProfessions() {
        const select = document.getElementById("profession-select");

        professions.forEach(profession => {
            let option = document.createElement("option");
            option.textContent = profession;
            option.value = profession;
            select.appendChild(option);
        });
    }

    populateProfessions();

    // Form validation
    const form = document.getElementById("registration-form");
    const fullnameInput = document.getElementById("fullname");
    const phoneInput = document.getElementById("phone");
    const dobInput = document.getElementById("dob");
    const emailInput = document.getElementById("email");
    const genderMaleInput = document.getElementById("gender-male");
    const genderFemaleInput = document.getElementById("gender-female");
    const professionSelect = document.getElementById("profession-select");

    form.addEventListener("submit", function(event) {
        event.preventDefault();
        if (validateForm()) {
            alert("Form submitted successfully!");
            form.reset();
        } else {
            document.getElementById("form-error").textContent = "Please fill out all required fields correctly.";
        }
    });

    // Validate form function
    function validateForm() {
        let isValid = true;

        resetErrorMessages();

        // Validate Full Name
        if (fullnameInput.value.trim() === "") {
            isValid = false;
            displayError("fullname-error", "Please enter your full name.");
        }

        // Validate Phone Number
        if (phoneInput.value.trim() === "") {
            isValid = false;
            displayError("phone-error", "Please enter your phone number.");
        }

        // Validate Date of Birth
        if (dobInput.value.trim() === "") {
            isValid = false;
            displayError("dob-error", "Please enter your date of birth.");
        }

        // Validate Email
        if (emailInput.value.trim() === "") {
            isValid = false;
            displayError("email-error", "Please enter your email address.");
        } else if (!isValidEmail(emailInput.value.trim())) {
            isValid = false;
            displayError("email-error", "Please enter a valid email address.");
        }

        // Validate Gender
        if (!genderMaleInput.checked && !genderFemaleInput.checked) {
            isValid = false;
            displayError("gender-error", "Please select your gender.");
        }

        // Validate Profession
        if (professionSelect.value === "") {
            isValid = false;
            displayError("profession-error", "Please select your profession.");
        }

        // Validate at least one Qualification checkbox is checked
        const qualificationInputs = document.querySelectorAll('input[name="Qualification"]');
        let isQualificationChecked = false;
        qualificationInputs.forEach(input => {
            if (input.checked) {
                isQualificationChecked = true;
            }
        });
        if (!isQualificationChecked) {
            isValid = false;
            displayError("qualification-error", "Please select at least one qualification.");
        }

        return isValid;
    }

    // Function to display error message
    function displayError(id, message) {
        const errorElement = document.getElementById(id);
        errorElement.textContent = message;
    }

    // Function to reset all error messages
    function resetErrorMessages() {
        const errorElements = document.querySelectorAll(".error-message");
        errorElements.forEach(element => {
            element.textContent = "";
        });
    }

    // Function to validate email format
    function isValidEmail(email) {
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return emailRegex.test(email);
    }

    // Event listeners for input blur (lost focus) to validate on each field
    fullnameInput.addEventListener("blur", function() {
        if (fullnameInput.value.trim() === "") {
            displayError("fullname-error", "Please enter your full name.");
        } else {
            display
            resetError("fullname-error");
        }
    });

    phoneInput.addEventListener("blur", function() {
        if (phoneInput.value.trim() === "") {
            displayError("phone-error", "Please enter your phone number.");
        } else {
            resetError("phone-error");
        }
    });

    dobInput.addEventListener("blur", function() {
        if (dobInput.value.trim() === "") {
            displayError("dob-error", "Please enter your date of birth.");
        } else {
            resetError("dob-error");
        }
    });

    emailInput.addEventListener("blur", function() {
        if (emailInput.value.trim() === "") {
            displayError("email-error", "Please enter your email address.");
        } else if (!isValidEmail(emailInput.value.trim())) {
            displayError("email-error", "Please enter a valid email address.");
        } else {
            resetError("email-error");
        }
    });

    // Function to reset a specific error message
    function resetError(id) {
        const errorElement = document.getElementById(id);
        errorElement.textContent = "";
    }

    // Event listener for form submission
    form.addEventListener("submit", function(event) {
        event.preventDefault();
        if (validateForm()) {
            alert("Form submitted successfully!");
            form.reset();
        } else {
            document.getElementById("form-error").textContent = "Please fill out all required fields correctly.";
        }
    });
});
