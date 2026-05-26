function toggleNav() {
    document.querySelector('.side-bar').classList.toggle('hide');
    document.querySelector('main').classList.toggle('main-full');
}


function showProfile() {
    const prof = document.querySelector("#Profile-Menu");
    if (prof.style.display === "none") {
        prof.style.display = "block";
    }
    else {
        prof.style.display ="none";
    }
}


function alertButton(type) {
    const alertBox = document.getElementById("alert-box");
    const alert = document.createElement("div");

    if (type == "default") {
        alert.innerText = "Click Other buttons";
        alert.className = "btn-primary alert-default";
    }


    if (type == "info") {
        alert.innerText = "Info : New features are now available";
        alert.className = "btn-primary alert-info";

    }
    if (type == "success") {
        alert.innerText = "Success: User has been created successfully!"
        alert.className = "btn-primary alert-success";

    }
    if (type == "warning") {
        alert.innerText = "Warning: This action cannot be undone";
        alert.className = "btn-primary alert-warning";
    }
    if (type == "error") {
        alert.innerText = "Error: Unable to save changes. Please try again.";
        alert.className = "btn-primary alert-error";
    }

    alertBox.appendChild(alert);

}


function tabs(type) {
    if (type == "overview") {
        document.getElementById('demo').innerText = "This is the overview tab content. ";
    }
    if (type == "setting") {
        document.getElementById('demo').innerText = "This is the setting tab content. ";

    }
    if (type == "detail") {
        document.getElementById('demo').innerText = "This is the detail tab content. ";
    }
}



var acc = document.getElementsByClassName("accordion");
var i;

for (i = 0; i < acc.length; i++) {
    acc[i].addEventListener("click", function () {
        this.classList.toggle("active");
        var panel = this.nextElementSibling;
        if (panel.style.maxHeight) {
            panel.style.maxHeight = null;
        }
        else {
            panel.style.maxHeight = panel.scrollHeight + "px";
        }
    });
}