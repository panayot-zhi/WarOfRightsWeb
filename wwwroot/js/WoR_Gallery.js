var images = 20;
var imagesContainerArray;
var currentImage = 1;
var player;
var thumbnails;

var galleryHeaderImages;
var galleryHeaderVideos;
var galleryHeaderBattlefieldMinutes;

function setVariables() {
    galleryHeaderImages = document.getElementById("galleryHeaderImages").style;
    galleryHeaderVideos = document.getElementById("galleryHeaderVideos").style;
    galleryHeaderBattlefieldMinutes = document.getElementById("galleryHeaderBattlefieldMinutes").style;
}

function enableGalleryImages() {
    galleryHeaderImages.borderLeftWidth = "3px";
    galleryHeaderImages.borderTopWidth = "3px";
    galleryHeaderImages.borderRightWidth = "3px";
    galleryHeaderImages.borderBottomWidth = "0px";

    galleryHeaderVideos.borderLeftWidth = "0px";
    galleryHeaderVideos.borderTopWidth = "0px";
    galleryHeaderVideos.borderRightWidth = "0px";
    galleryHeaderVideos.borderBottomWidth = "3px";

    galleryHeaderBattlefieldMinutes.borderLeftWidth = "0px";
    galleryHeaderBattlefieldMinutes.borderTopWidth = "0px";
    galleryHeaderBattlefieldMinutes.borderRightWidth = "0px";
    galleryHeaderBattlefieldMinutes.borderBottomWidth = "3px";
}

function enableGalleryVideos() {
    galleryHeaderImages.borderLeftWidth = "0px";
    galleryHeaderImages.borderTopWidth = "0px";
    galleryHeaderImages.borderRightWidth = "0px";
    galleryHeaderImages.borderBottomWidth = "3px";

    galleryHeaderVideos.borderLeftWidth = "3px";
    galleryHeaderVideos.borderTopWidth = "3px";
    galleryHeaderVideos.borderRightWidth = "3px";
    galleryHeaderVideos.borderBottomWidth = "0px";

    galleryHeaderBattlefieldMinutes.borderLeftWidth = "0px";
    galleryHeaderBattlefieldMinutes.borderTopWidth = "0px";
    galleryHeaderBattlefieldMinutes.borderRightWidth = "0px";
    galleryHeaderBattlefieldMinutes.borderBottomWidth = "3px";
}

function enableBattlefieldMinutes() {
    galleryHeaderImages.borderLeftWidth = "0px";
    galleryHeaderImages.borderTopWidth = "0px";
    galleryHeaderImages.borderRightWidth = "0px";
    galleryHeaderImages.borderBottomWidth = "3px";

    galleryHeaderVideos.borderLeftWidth = "0px";
    galleryHeaderVideos.borderTopWidth = "0px";
    galleryHeaderVideos.borderRightWidth = "0px";
    galleryHeaderVideos.borderBottomWidth = "3px";

    galleryHeaderBattlefieldMinutes.borderLeftWidth = "3px";
    galleryHeaderBattlefieldMinutes.borderTopWidth = "3px";
    galleryHeaderBattlefieldMinutes.borderRightWidth = "3px";
    galleryHeaderBattlefieldMinutes.borderBottomWidth = "0px";
}

function createGalleryImages() {
    console.log("createGalleryImages");
    var gallery = "";
    for (var i = 1; i < images + 1; i++) {
        gallery += "<img class='galleryImageContainer worTightBorder' src='Content/Images/Gallery/wor_" + (i) + "_min.jpg' onclick='openLightBox(" + (i) + ")'/>";
    }
    document.getElementById("galleryImages").innerHTML = gallery;

    thumbnails = document.getElementsByClassName("galleryImageContainer");
}

function openLightBox(image) {
    document.getElementById("lightBoxImage").src = "/Content/Images/Gallery/wor_" + image + ".jpg";
    document.getElementById("lightBoxContainer").style.visibility = "visible";
    document.getElementById("lightBoxShadow").style.visibility = "visible";

    for (var i = 0; i < thumbnails.length; i++) {
        thumbnails[i].style.pointerEvents = "none";
    }

    currentImage = image;

    updateImageContainerArray();
    window.setTimeout(fitImageToScreen, 150);
}

function closeLightBox() {
    document.getElementById("lightBoxImage").src = "";
    document.getElementById("lightBoxContainer").style.visibility = "hidden";
    document.getElementById("lightBoxShadow").style.visibility = "hidden";

    for (var i = 0; i < thumbnails.length; i++) {
        thumbnails[i].style.pointerEvents = "all";
    }
}

function nextImage() {
    document.getElementById("lightBoxImage").src = imagesContainerArray[2].src;

    if (currentImage + 1 > images) {
        currentImage = 1;
    }
    else {

        currentImage = currentImage + 1;
    }

    fitImageToScreen();
    updateImageContainerArray();
}

function previousImage() {
    document.getElementById("lightBoxImage").src = imagesContainerArray[0].src;

    if (currentImage < 2) {
        currentImage = images;
    }
    else {
        currentImage = currentImage - 1;
    }

    fitImageToScreen();
    updateImageContainerArray();
}

function fitImageToScreen() {
    if (document.getElementById("lightBoxContainer").style.visibility == "visible") {
        image = new Image;
        image.src = "/Content/Images/Gallery/wor_" + currentImage + ".jpg";

        var currentImageRawHeight = image.height;
        var currentImageRawWidth = image.width;

        var newHeight;
        var newWidth;

        var browserWidth = window.innerWidth;
        var browserHeight = window.innerHeight;
        var marginSides = 50;
        var marginTop = 50;

        var imageWidth = browserWidth - marginSides;
        var imageHeight = browserHeight - marginTop;

        // calculates image height while maintaining the aspect ratio
        newHeight = (currentImageRawHeight / currentImageRawWidth) * imageWidth;
        newWidth = (currentImageRawWidth / currentImageRawHeight) * imageHeight;

        document.getElementById("lightBoxImage").style.width = imageWidth + "px";
        document.getElementById("lightBoxImage").style.height = newHeight + "px";
        document.getElementById("lightBox").style.left = ((browserWidth / 2) - (imageWidth / 2)) + "px";
        document.getElementById("lightBox").style.top = ((browserHeight / 2) - (newHeight / 2)) + "px";
        //if the image is taller than the browser window the image will be scaled on its height

        if (newHeight + marginTop > browserHeight) {
            // calculates image width while maintaining the aspect ratio
            newWidth = (currentImageRawWidth / currentImageRawHeight) * imageHeight;

            document.getElementById("lightBoxImage").style.height = imageHeight + "px";
            document.getElementById("lightBoxImage").style.width = newWidth + "px";
            document.getElementById("lightBox").style.left = ((browserWidth / 2) - (newWidth / 2)) + "px";
            document.getElementById("lightBox").style.top = ((browserHeight / 2) - (imageHeight / 2)) + "px";
        }
    }
}

function updateImageContainerArray() {
    if (currentImage < 2) {
        image1 = new Image;
        image1.src = "/Content/Images/Gallery/wor_" + (images) + ".jpg";
    }
    else {

        image1 = new Image;
        image1.src = "/Content/Images/Gallery/wor_" + (currentImage - 1) + ".jpg";
    }

    image2 = new Image;
    image2.src = "/Content/Images/Gallery/wor_" + currentImage + ".jpg";

    if (currentImage + 1 > images) {
        image3 = new Image;
        image3.src = "/Content/Images/Gallery/wor_" + 1 + ".jpg";
    }
    else {
        image3 = new Image;
        image3.src = "/Content/Images/Gallery/wor_" + (currentImage + 1) + ".jpg";
    }

    imagesContainerArray = [image1,
        image2,
        image3
    ];
}