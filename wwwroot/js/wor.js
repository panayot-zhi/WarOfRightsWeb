function startPlacePosters() {
    var n = document.URL, t = n.substring(n.lastIndexOf("/") + 1);
    t == "" ? (console.log("startPlacePosters"), window.setTimeout(placePosters, 500)) : placePosters()
}

function placePosters() {
    for (var f, e, i, l, o = 8, n = 0; n < o; n++) {
        var a = n + 1, u = -1, s = 0, h = 0, c = 1;
        if (Math.random() > .5) c = 0;
        else {
            while (u == -1) {
                for (f = !1, e = Math.floor(Math.random() * 19 + 1), i = 0; i < posters.length; i++)
                    if (posters[i][1] == e) {
                        f = !0;
                        break
                    }
                f || (u = e)
            }
            var r = document.body,
                t = document.documentElement,
                v = Math.max(r.scrollHeight, r.offsetHeight, t.clientHeight, t.scrollHeight, t.offsetHeight),
                y = Math.max(r.scrollWidth, r.offsetWidth, t.clientWidth, t.scrollWidth, t.offsetWidth);
            s = Math.floor(Math.random() * y);
            h = Math.floor(Math.random() * v)
        }
        posters.push([a, u, s, h, c])
    }
    for (n = 0; n < o; n++)
        poster = document.getElementById("poster" + posters[n][0]), posters[n][4] == 1
            ? (poster.src = "/Content/Images/Posters/" + posters[n][1] + ".png", poster.style.left =
                posters[n][2] + "px", poster.style.top = posters[n][3] + "px", l =
                Math.floor(Math.random() * 31 - 15), poster.style.transform = "rotate(" + l + "deg)")
            : poster.style.display = "none";
    scrollPosters()
}

function scrollPosters() {
    for (var n = 0; n < posters.length; n++)
        posters[n][4] == 1 &&
            (document.getElementById("poster" + posters[n][0]).style.top = posters[n][3] - $(window).scrollTop() + "px")
}

function openRandomCompanyToolRegiment() { window.location.replace("/CT_ViewCompany#companyToolHeader") }

function RaiseYourPledgeBy(n) { document.getElementById("tbPledgeAmount").value = n }

function RaiseYourPledgeByCustom() {
    var n = document.getElementById("tbPledgeAmount").value;
    n == ""
        ? (document.getElementById("errorMessage").innerHTML =
            "You need to type an amount!", document.getElementById("errorMessage").style.visibility = "visible")
        : /^\d+$/.test(n)
        ? (document.getElementById("amountToPledge").value = n, document.getElementById("raisePledgeForm").submit())
        : (document.getElementById("errorMessage").innerHTML =
            "The amount can only contain numbers!", document.getElementById("errorMessage").style.visibility =
            "visible")
}

function GoToRewardTier(n) {
    console.log(n);
    window.location.href = "#" + n
}

function setVariables() {
    galleryHeaderImages = document.getElementById("galleryHeaderImages").style;
    galleryHeaderVideos = document.getElementById("galleryHeaderVideos").style;
    galleryHeaderBattlefieldMinutes = document.getElementById("galleryHeaderBattlefieldMinutes").style
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
    galleryHeaderBattlefieldMinutes.borderBottomWidth = "3px"
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
    galleryHeaderBattlefieldMinutes.borderBottomWidth = "3px"
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
    galleryHeaderBattlefieldMinutes.borderBottomWidth = "0px"
}

function createGalleryImages() {
    var t, n;
    for (console.log("createGalleryImages"), t = "", n = 1; n < images + 1; n++)
        t += "<img class='galleryImageContainer worTightBorder' src='Content/Images/Gallery/wor_" +
            n +
            "_min.jpg' onclick='openLightBox(" +
            n +
            ")'/>";
    document.getElementById("galleryImages").innerHTML = t;
    thumbnails = document.getElementsByClassName("galleryImageContainer")
}

function openLightBox(n) {
    document.getElementById("lightBoxImage").src = "/Content/Images/Gallery/wor_" + n + ".jpg";
    document.getElementById("lightBoxContainer").style.visibility = "visible";
    document.getElementById("lightBoxShadow").style.visibility = "visible";
    for (var t = 0; t < thumbnails.length; t++) thumbnails[t].style.pointerEvents = "none";
    currentImage = n;
    updateImageContainerArray();
    window.setTimeout(fitImageToScreen, 150)
}

function closeLightBox() {
    document.getElementById("lightBoxImage").src = "";
    document.getElementById("lightBoxContainer").style.visibility = "hidden";
    document.getElementById("lightBoxShadow").style.visibility = "hidden";
    for (var n = 0; n < thumbnails.length; n++) thumbnails[n].style.pointerEvents = "all"
}

function nextImage() {
    document.getElementById("lightBoxImage").src = imagesContainerArray[2].src;
    currentImage = currentImage + 1 > images ? 1 : currentImage + 1;
    updateImageContainerArray();
    fitImageToScreen()
}

function previousImage() {
    document.getElementById("lightBoxImage").src = imagesContainerArray[0].src;
    currentImage = currentImage < 2 ? images : currentImage - 1;
    updateImageContainerArray();
    fitImageToScreen()
}

function fitImageToScreen() {
    if (document.getElementById("lightBoxContainer").style.visibility == "visible") {
        image = new Image;
        image.src = "/Content/Images/Gallery/wor_" + currentImage + ".jpg";
        var u = image.height,
            f = image.width,
            n,
            t,
            e = window.innerWidth,
            i = window.innerHeight,
            s = 50,
            o = e - 50,
            r = i - s;
        n = u / f * o;
        t = f / u * r;
        document.getElementById("lightBoxImage").style.width = o + "px";
        document.getElementById("lightBoxImage").style.height = n + "px";
        document.getElementById("lightBox").style.left = e / 2 - o / 2 + "px";
        document.getElementById("lightBox").style.top = i / 2 - n / 2 + "px";
        n + s > i &&
        (t = f / u * r, document.getElementById("lightBoxImage").style.height =
            r + "px", document.getElementById("lightBoxImage").style.width =
            t + "px", document.getElementById("lightBox").style.left =
            e / 2 - t / 2 + "px", document.getElementById("lightBox").style.top = i / 2 - r / 2 + "px")
    }
}

function updateImageContainerArray() {
    currentImage < 2
        ? (image1 = new Image, image1.src = "/Content/Images/Gallery/wor_" + images + ".jpg")
        : (image1 = new Image, image1.src = "/Content/Images/Gallery/wor_" + (currentImage - 1) + ".jpg");
    image2 = new Image;
    image2.src = "/Content/Images/Gallery/wor_" + currentImage + ".jpg";
    currentImage + 1 > images
        ? (image3 = new Image, image3.src = "/Content/Images/Gallery/wor_1.jpg")
        : (image3 = new Image, image3.src = "/Content/Images/Gallery/wor_" + (currentImage + 1) + ".jpg");
    imagesContainerArray = [image1, image2, image3]
}

function adjustLinesOnTextBox(n) { n.style.backgroundPositionY = -n.scrollTop + "px" }

function underlineNavigation() {
    var t = document.URL, n = t.substring(t.lastIndexOf("/") + 1);
    n == ""
        ? document.getElementById("navHome").style.textDecoration = "underline"
        : n == "News"
        ? document.getElementById("navNews").style.textDecoration = "underline"
        : n == "Media"
        ? document.getElementById("navMedia").style.textDecoration = "underline"
        : n == "FAQ"
        ? document.getElementById("navFAQ").style.textDecoration = "underline"
        : n == "Contact" && (document.getElementById("navContact").style.textDecoration = "underline");
    console.log(n)
}

function HighlightElement(n) {
    for (var i = document.getElementsByClassName("hoverOverlayNormalCursor"), t = 0; t < i.length; t++)
        i[t].style.backgroundColor = null;
    n.style.backgroundColor = "rgba(255,255,255,0.5)"
}

function moveDrillCampHeaders() {
    userStartedScrolling = !0;
    var n = $(window).scrollTop() / 2.1, t = "-" + n + "px", i = "rect(" + n + "px,1019px," + (n + 60) + "px,0px)";
    try {
        DrillCampColor.style.clip = i;
        DrillCampNoColor.style.clip = i;
        DrillCampColor.style.marginTop = t;
        DrillCampNoColor.style.marginTop = t
    } catch (r) {
    }
}

function createFrontPageLatestNews() {
    var t, n;
    for (createBriefNewsItems(), t = "<h1 class='text-center'>Latest News<\/h1>", n = newsItems.length - 1;
        n >= newsItems.length - 4;
        n--)
        t += "<a href='" +
            newsItems[n][2] +
            "'><div class='latestNewsItem'><img src='" +
            newsItems[n][1] +
            "' class='worTightBorder'/><div class='newsTextCenterDiv'><h3>" +
            newsItems[n][0] +
            "<\/h3><h3>" +
            newsItems[n][4] +
            "<\/h3><\/div><\/div><\/a>";
    document.getElementById("latestNews").innerHTML = t
}

function createBriefNews() {
    var t, n;
    for (console.log("createBriefNews"), createBriefNewsItems(), t = "", n = newsItems.length - 1; n >= 0; n--)
        t += "<a href='" +
            newsItems[n][2] +
            "'><div class='briefFieldReportContainer'><img src='" +
            newsItems[n][1] +
            "' class='worTightBorder'/><div class='briefDescription'><div><h2 class='briefFieldReportName'>" +
            newsItems[n][0] +
            "<\/h2><h2 class='briefFieldReportDate'>" +
            newsItems[n][4] +
            "<\/h2><\/div><p class='fancyClearBoth'>" +
            createShortDescriptionAnnouncement(newsItems[n][3]) +
            "...<\/p><\/div><\/div><\/a>";
    document.getElementById("briefNewsContainer").innerHTML = t
}

function createShortDescriptionAnnouncement(n) {
    for (var t = n.substr(0, descriptionLength), i = t.charAt(t.length - 1); i == " " || i == "." || i == ",";)
        t = t.substr(0, t.length - 1), i = t.charAt(t.length - 1);
    return t
}

function createBriefNewsItems() {
    console.log("createBriefNewsItems");
    newsItems = [
        [
            "Field Report 1: Battle of Antietam/Sharpsburg", "Pages_FieldReports/FieldReport1/Fieldreport1_thumb.jpg",
            "/Fieldreport1",
            "This is where we're going to give you the insights of the project in the future.         I should mention that the information below is all subject to change,         but I thought you'd like to know what exactly we're up to at the moment.         We are currently working on producing assets in order to create our very first map,         The battle of Antietam or Sharpsburg as the southerners called it.         We've got a pretty good idea of what we want with the map design and which battlefield sites to include         Just as in the real battle, the confederates are on the defensive, spawning at two points;         at the Dunker church and at the sunken road or bloody lane northwest of the lower bridge         (or Burnside's Bridge at it became known as after the battle) to the southeast of the map",
            "28/5 - 2012"
        ],
        [
            "Field Report 2: Vegetation", "Pages_FieldReports/FieldReport2/Fieldreport2_thumb.jpg", "/Fieldreport2",
            "For the past month we've been busy working on vegetation and ground textures primarily.         We began the process by going on a field trip into the dense (and dangerous!) woods of Denmark.         With us, we brought a camera, a white plastic bag and some camo clothes to look the part.         The hunt for textures was on! We spent until sundown capturing several useful textures like:         We've got lots of textures out of the trip. Some are implemented (such as the forrest we've shown)         others are still to be modelled and given a texture. I'm busy planting forrests around the map and         prepping the site of the Dunker Church at the moment, while Fancy Sweetroll has got his hands full         with the Dunker Church model. Screenshots of the iconic church should be ready quite soon. Meanwhile,         we've got a friend who's experienced in the art of homepage design to help us out with our website Warofrights.com",
            "20/8 - 2012"
        ],
        [
            "Field Report 3: textures, churches & website launch",
            "Pages_FieldReports/FieldReport3/Fieldreport3_thumb.jpg", "/Fieldreport3",
            "Since the last report, we've been out on another field trip in order to capture textures and reference         photos to be used while creating various models.We sat out to capture more of the agricultural fields         this time instead of the woods as we did last time. The wheatfields had just been harvested (which they         also had during the battle of Antietam).That allowed us to get some nice ground texture photos. After the         wheatfield, we found a cornfield and got some rather nice reference pictures we'll put to great use when         modelling the corn plants.We also came by an old church where we captured several useful         textures like the base difuse texture for the Dunker church.         The iconic Dunker church is now nearly completed. It still needs a bit of details, and as of now,         it has no furniture. The church is one of the iconic scenes of the battle. Others already implemented or planned are",
            "29/8 - 2012"
        ],
        [
            "Field Report 4: The Evolution of the Springfield M1861",
            "Pages_FieldReports/FieldReport4/Fieldreport4_thumb.jpg", "/Fieldreport4",
            "This field report showcases the process the Springfield M1861 has gone through in production.         You may have noticed that we haven't posted anything in a while, and some of you may even have wondered if the project has died.         But I'm pleased to say that the team have just taken a small holiday and are now back in action!The first model I made for War of Rights         was the Springfield M1861. Many of our models has gone through a couple of iterations.         But this rifle however is the one that has gone through the most. Or well, in fact thats's a lie.         The first model I made for the game was the Henry rifle which was a disaster.. Considering that it was for a game         I've highlighted some of the errors and as you can see it is nowhere near perfect.         But at the time I was quite proud of it.One of the first things I decided to change         was the wood around the metal plate that the hammer is attached to. This wood was actually",
            "24/10 - 2012"
        ],
        [
            "Field Report 5: New faces and the future", "Pages_FieldReports/FieldReport5/Fieldreport5_thumb.jpg",
            "/Fieldreport5",
            "Much has happened since our last report back in october. We've been going through nearly every asset in         order to refine it to meet our standards duing the past few months. New trees, better LOD's,         billboards for long distance rendering. new types of grass making it easier for us to follow specific         patterns like a road, various updated sprites as well as a few new ones (flowers, wheatfield),         small randomly generated stones and rocks to clutter the grass fields, the roads and the ford in the         northern end of Antietam creek. Dunker church has been given a facelift since last time         (it didn't have the correct dimensions before) as well as Burnside Bridge who has been given         a new tileable texture in order to up the resolution size and the prettiness of the whole model.         All ground textures have been updated with parallax occlusion mapping in order to bring the textures a bit of 3D magic",
            "30/12 - 2012"
        ],
        [
            "Field Report 6: First flyby trailer", "Pages_FieldReports/FieldReport6/Fieldreport6_thumb.jpg",
            "/Fieldreport6",
            "Today, the WoR dev team has reached a milestone. We've just released our first trailer.         The trailer is all about showing you some of the (mostly) complete scenes in the Antietam         map as well as revealing our theme composed and created by Noah Saberhagen.         Please note that everything shown is still very much a work in progress.         Without further ado, here's the first part of our Antietam flyby trailer!         Since the last field report, we've expanded the dev team even more. t.mclaughlin, a 3D enviroment artist and Jasmine.         You'll see some of t.mclaughlin's work in the form of Pry House in the trailer.         Jasmine is currently working on our first player model which we'll look forward to be showing you in a later field report.         We've launched our forum at: https://warofrights.com/forum/forum.php as well since the last field report",
            "16/2 - 2013"
        ],
        [
            "Field Report 7: Union", "Pages_FieldReports/FieldReport7/Fieldreport7_thumb.jpg", "/Fieldreport7",
            'Today we have the pleassure to annouce that the North and South development team is joining         the WoR team to help deliver the best Civil War experience possible. We are sure this will         be a huge benefit to the overall experience when playing War of Rights and we would therefore         like to welcome Hinkel, Nytech, Primergy and Dennizjoon to the team!         In order to publicly announce "the union" of the teams. Hinkel has created an updated flyby trailer of Antietam - enjoy!         Other new faces have joined the dev team now known as BlueHill Studios since the last field report         Sgt-Frede has been busy creating weapons for us (Sharps, Enfield and is now working on the colt army 1860).         Stefan, a 3D modeler is one of our newest additions to the team.         He\'s been busy creating some of the historical barns for us. Here we have Pry barn',
            "15/3 - 2013"
        ],
        [
            "Field Report 8: Upgrades!", "Pages_FieldReports/FieldReport8/Fieldreport8_thumb.jpg", "/Fieldreport8",
            "It’s been a long while since our last one (over 5 months!) and a lot has happened with WoR since then.         One of the top priorities the past few months has been the retweaking of nearly all of our assets in terms         of optimizing and to gain the look we wanted. Our grass has been a big one – we’ve been through so many         iterations! Lots of new buildings have been modeled – 20 or so historically accurate structures are finished         and are just awaiting texturing before they’ll create new scenes of the Antietam battlefield.         We’ve also been hard at work creating characters, a task not quite so easy when you’re after         that authentic “mixed bag” as the general look of the confederates indeed was.         More on our variations as we move closer to being finished with them!         A week ago, Crytek, the creators of CRYENGINE, released an all new build of their engine",
            "29/8 - 2013"
        ],
        [
            "Field Report 9: Characters!", "Pages_FieldReports/FieldReport9/Fieldreport9_thumb.jpg", "/Fieldreport9",
            "Today we’re going to show you the very first characters in War of Rights.         They represent a huge milestone for us and the entire team has very much looked         forward to the moment the first ones would be revealed to the public (now!).         Our character artist, Said, has really been crunching as of late,         and we’re extremely glad to have him on our team.         We want to have a huge amount of variation of the soldiers in War of Rights -         there were extremely many different uniforms in the civil war, too many in fact.         This is why we’re going to start off by focusing on the “common” soldiers.         In other words, we’re going to begin the huge character creation process by         creating the soldiers you were most likely to see on the battlefield.",
            "9/11 - 2013"
        ],
        [
            "Field Report 10: Refinements", "Pages_FieldReports/FieldReport10/Fieldreport10_thumb.jpg",
            "/Fieldreport10",
            "We've recently been joined by a talented character artist named Pat.         He's only been with us for a few weeks but we're already seeing great characters come to life.         Here are a few renders of his WIP 114th Pennsylvania zouave enlisted soldier:         The 114th Pennsylvania Zouaves originated as a small company first organized by a Philadelphia         lawyer by the name of Charles Collis, who became the Captain of the Company. At this time,         the company was known as the \"Zouaves d'Afrique,\" and they were attached to other regiments while serving         Their first meeting of shot and shell was in the Shenandoah Campaign, as well as in the Battle of Antietam.         Due to their splendid performances in battle, their fighting prowess, and their overall dash and vigour,         they were approved to raise a full regiment with Collis as its Colonel. They were renamed to the 114th PA Zouaves",
            "2/2 - 2014"
        ],
        [
            "Field Report 11: The creation of maps", "Pages_FieldReports/FieldReport11/Fieldreport11_thumb.jpg",
            "/Fieldreport11",
            "Today I'd like to talk to you a bit about the map creation process for War of Rights.         We've been focusing on creating Antietam more or less exclusively until a short while         ago when we began on the battle of South Mountain as well. It's been an internal plan         for ages to recreate the whole of the Maryland campaign of 1862 and now we feel like it's         time to let you guys know a thing or two about it as well – more on the subject of the future         features of WoR a little later. First, I'd like to take you through the earliest phases of the creation of South Mountain.         First, we sit down and plan the boundaries of the map – the playable area.         In South Mountain's case the size of the battlefield is much too long for us to include all of it.         Because of this, we've decided to focus on the two northern main points of engagement",
            "1/3 - 2014"
        ],
        [
            "Field Report 12: Content update", "Pages_FieldReports/FieldReport12/Fieldreport12_thumb.jpg",
            "/Fieldreport12",
            "Ladies and gents! I'm very glad to be able to bring you the latest news from the frontline         that is the development of War of Rights. It's been a while since the last field report –         several months in fact. A lot of work behind the scenes have been happening between field         report 11 and now. In late may, Crytek released the eaas version of CRYENGINE on steam which         we have been spending some time getting to know the features of, the main new feature being the inclusion of PBR –         physically based rendering. Another item that's been taking quite a lot of our time is the creation of WoR's third map:         Harper's Ferry. Heightmaps are being used along with tons of reference photos and town layout         maps in order to assure the authenticity and attention to detail are being pushed to the limit.         If you want to learn more about the siege of Harper's Ferry, I suggest you look up our historical advisor",
            "5/7 - 2014"
        ],
        [
            "Field Report 13: Character Teaser", "Pages_FieldReports/FieldReport13/Fieldreport13_thumb.jpg",
            "/Fieldreport13",
            "War of Rights celebrates the lives of the lost soldiers on this 17th of September,         152 years after the rolling gunfire first resounded over the hills and valleys,         and offers a small teaser with a very early look at the members of the Corps D'Afrique!         Mr. D.R. Miller of Antietam had no idea of the butchery that would go on in his fields as         the autumn days turned their color from a rich green to a golden tan. Before he could harvest them,         the area became swarmed with the opposing troops of the Union and Confederacy.         On Nicodemus Hill to the left and Dunker Church to the south, cannons roared their cacophonous song,         as screaming balls of lead soared into the ranks of the blue-clad men entering the field.         Within two hours, the 16,500 men of both sides had inflicted on each other over 13,000",
            "17/9 - 2014"
        ],
        [
            "Field Report 14: A Tour of Antietam", "Pages_FieldReports/FieldReport14/Fieldreport14_thumb.jpg",
            "/Fieldreport14",
            "For this field report, we thought we'd give you a rather lengthy treat, as well as a raw,         uncut look at one of our featured battlefields: Antietam. The 40 (!) minute video is narrated         by our very own historical advisor, GeorgeCrecy - providing you all with plenty of historical         context while looking at the scenery. We'd like to (as always) state that what you're about to         see is still very much in a form of early development and that everything is subject to change.         With that being said, go get a drink, get comfortable and join George on his virtual tour of Antietam - enjoy!         That's all for now - We'll be back in a little while, showing you all some more action packed content. Until next time, have a good one!",
            "5/10 - 2014"
        ],
        [
            "Field Report 15: Updates", "Pages_FieldReports/FieldReport15/Fieldreport15_thumb.jpg", "/Fieldreport15",
            "We’ve updated our website at https://warofrights.com/         quite a bit in order to present our game to the first time visitors a bit better.         It is now possible to find an F.A.Q. section which will answer the most commonly asked questions.         The forum has also gotten an update in visuals.         Stuart has given the much loved and widely used Pattern 1853 Enfield an overhaul.         We didn’t feel like the original enfield rifle we had held up well enough         to the other assets ingame so he was charged with creating a new one.         Heres a render of the low poly, ingame ready result.         Pat has been working on adding additional face and hair variations         to the characters in general as well as adding a few new items such as the forage cap.         He’s also completed the union private sack coat wearer.         Here’s a few ingame screenshots of the additions.",
            "21/10 - 2014"
        ],
        [
            "Field Report 16: Goodbye 2014", "Pages_FieldReports/FieldReport16/Fieldreport16_thumb.jpg",
            "/Fieldreport16",
            "The first confederate soldiers are now ingame. They all wear Richmond Depot Type II jacket (a shell jacket)         as well as carrying Enfield rifles. We now support all the most commonly worn jackets of the war (except         for great coats which really did not see a great deal of use in the Maryland campaign) – sack and frock coats         as well as shell jackets. Here are a few screenshots of our new southern gentlemen:         A few new scenes has been completed at Antietam as well: Otto Farm – the neighboring farm to the         Sherricks as well as Pry’s Grist Mill – one of the largest gristmills of the area located at Little Antietam not         far from Keedysville. We have upped our effective force quite a bit since last time and would therefore like to welcome Andrei –         a 3d artist, Igor – a level designer and Julius – a programmer to the team. We’re very much looking forward         to what they along with the rest of the team will be able to bring to the table in 2015.",
            "31/12 - 2014"
        ],
        [
            "Announcement: Features Page",
            "Pages_FieldReports/FieldReport16_Announcement/FieldReport16_1_AnnouncementFeatures_thumb.jpg",
            "/Announcement1",
            "Today, we’re happy to announce the launch of our features page on our website: https://warofrights.com/Features         The features page showcases some of the features currently ingame and will be updated and expanded upon as development moves forward.         We hope you all will enjoy it!",
            "20/2 - 2015"
        ],
        [
            "Field Report 17: The Oregon Campaign", "Pages_FieldReports/FieldReport17/Fieldreport17_thumb.jpg",
            "/Fieldreport17",
            "A little less than a month ago, the two danish founders of Campfire Games,         Emil Alexander Hansen (Fancy Sweetroll) and Mads Støjko Larsen (TrustyJam)          had the chance to visit the historical advisor of the team, George Crecy in Oregon.        The field trip only lasted three days but Clark still managed to present (and talk about!) a whole lot of         relevant civil war related items as well as experiences: Presentations at a local museum, a chance to try on the union uniform,         demonstrations of correct soldier movements as well as a visit to the gunrange where black powder weapons were fired just to name        a few.",
            "20/3 - 2015"
        ],
        [
            "Field Report 18: Marching Johnny", "Pages_FieldReports/FieldReport18/Fieldreport18_thumb.jpg",
            "/Fieldreport18",
            "Today, we bring you a few short ingame videos. The first one is showcasing our free-look         mechanic which will be essential in order to make sure the formation of the regiment is         kept in a functional state. By pressing “alt” the player is able to freely look around while being on the move.         The second video is showcasing our rifle reload animation, this time from a third person perspective. Enjoy!         Our forests have been going through yet another asset update.         Below are a few screenshots of the new look as well as an old screenshot for comparison. ",
            "21/5 - 2015"
        ],
        [
            "Field Report 19: Graphical Updates", "Pages_FieldReports/FieldReport19/Fieldreport19_thumb.jpg",
            "/Fieldreport19",
            "Today, we’ll be bringing a look at a few new rendering features, environment updates and a overall project status update.         The latest version of CRYENGINE brings voxel-based global illumination which creates dynamic         indirect light bounces from objects as well as indirect shadows.         This helps to remove the flat look that can often be found in the shadows of most games.         Below are a few examples showing the new feature.         In addition to this, we have updated all the grass in the game.         War of Rights has been in development for the better part of three years now. It started as hobby",
            "30/7 - 2015"
        ],
        [
            "Field Report 20: Kickstarter Announcement", "Pages_FieldReports/FieldReport20/Fieldreport20_thumb.jpg",
            "/Fieldreport20",
            "In order to be able to push the development to the next level and get the game out         in a much more polished state as well in a more timely manner, we feel like Kickstarter is an obvious option to explore.         The Kickstarter campaign will feature a wide range of pledge tiers (1-500 USD) as well as exclusive Kickstarter backer rewards.         It will also highlight a bunch of gameplay systems we haven't talked about or shown yet.         We hope you'll all check us out when we open the doors on October 15th and will help us to         spread the news of the existance of the campaign to all whom you think may be interested.         That is all for now. We'll leave you with a collection of screenshots and historical background information we've released in the past few weeks.",
            "7/9 - 2015"
        ],
        [
            "Field Report 21: Kickstarter Launched", "Pages_FieldReports/FieldReport21/Fieldreport21_thumb.jpg",
            "/Fieldreport21",
            "The time has catch (Exception) { } finally come for us to launch the Kickstarter campaign for War of Rights! We hope you like what you see.         Gaining momentum quickly is one of the most important aspects of a crowdfunding campaign so we would really appreciate         it if you help us by spreading the word and sharing the link to the Kickstarter for War of Rights!         You can find the Kickstarter campaign by clicking on this link: KS LINK or simply by clicking on the image above.         We’ve also just launched our Steam Greenlight campaign so please vote for us! If we’re approved on Steam Greenlight we’ll         be working on a Steam version for War of Rights once the Kickstarter campaign is over, as long as we manage to make it to the main goal!         We will release several updates during the Kickstarter campaign, and we’ll be using the for detailing game mechanics and         talking more about the setting for the game, so be sure to check those to learn more about the game.         That’s all for now. We hope you’re as excited about the next 30 days as we are!",
            "15/10 - 2015"
        ],
        [
            "Kickstarter Update 1: Thank you!", "Pages_FieldReports/KickstarterUpdate1/KickstarterUpdate1_thumb.jpg",
            "/KickstarterUpdate1",
            "Hello everyone! Welcome to the very first of our campaign updates.         Throughout the campaign we’re going to be releasing several updates detailing the gameplay         features of War of Rights as well as showcasing more assets from the game.         We're currently at 17% funded in a single day thanks to over £12,000 in pledges!         So for today, it is all about thanking you, our earliest backers and supporters.         A crowdfunding campaign relies heavily on gaining momentum as quickly as possible as well as on word of mouth.         We’d like to thank everyone who’s been showing their support either in the form of new         pledges or in helping to raise awareness on the campaign. So, to sum things up: ",
            "16/10 - 2015"
        ],
        [
            "Kickstarter Update 2: Skirmishes", "Pages_FieldReports/KickstarterUpdate2/KickstarterUpdate2_thumb.jpg",
            "/KickstarterUpdate2",
            "Welcome again! It’s time to talk about one of the game modes for War of Rights.         Before we kick these off, we’d like you all to please keep in mind that the mechanics are still very much a work-in-progress scenario.         Things will get added, removed or completely overhauled as the development continues and we begin playtesting. With that out of the way,         let’s dig into the first game mode for War of Rights!         So for today, it is all about thanking you, our earliest backers and supporters.         A crowdfunding campaign relies heavily on gaining momentum as quickly as possible as well as on word of mouth.         We’d like to thank everyone who’s been showing their support either in the form of new         pledges or in helping to raise awareness on the campaign. So, to sum things up: ",
            "19/10 - 2015"
        ],
        [
            "Kickstarter Update 3: Historical Battles",
            "Pages_FieldReports/KickstarterUpdate3/KickstarterUpdate3_thumb.jpg", "/KickstarterUpdate3",
            "Welcome to our third project update! Today we'll continue talking about the game modes for War of Rights,         and that means it's time to talk about Historical Battles! And at the end of today's update we'll also be         talking about a few Kickstarter campaigns we're backing and that could use some of your support.         Our second game mode is Historical Battles. This behemoth of a game mode functions much like the smaller Skirmishes in the way of progression.         They too include an offensive and defensive side based on the real battles fought during the American Civil War.         For example, this means that the Confederates will be on the defensive at Antietam but on the offensive at Harper’s Ferry.",
            "21/10 - 2015"
        ],
        [
            "Kickstarter Update 4: Classes", "Pages_FieldReports/KickstarterUpdate4/KickstarterUpdate4_thumb.jpg",
            "/KickstarterUpdate4",
            "Welcome to our fourth Kickstarter update! Before we kick these off,         we’d like you all to please keep in mind that the mechanics we'll be discussing are still very much a work in progress.         Things will get added, removed or completely overhauled as the development continues and we begin playtesting each build.         With that out of the way, let’s dig into the classes of War of Rights!         When joining a server in War of Rights, you start out by selecting which faction you want to play as:         USA or CSA. After that you will be presented with the options above.         First you select which regiment you want to join. There will be regular infantry regiments and sharpshooter regiments.         Uniforms and weapon availability will depend on which regiment the player selects to join. ",
            "23/10 - 2015"
        ],
        [
            "Kickstarter Update 5: Chain of Command",
            "Pages_FieldReports/KickstarterUpdate5/KickstarterUpdate5_thumb.jpg", "/KickstarterUpdate5",
            "Welcome to our fourth Kickstarter update! Before we kick these off,         we’d like you all to please keep in mind that the mechanics we'll be discussing are still very much a work in progress.         Things will get added, removed or completely overhauled as the development continues and we begin playtesting each build.         With that out of the way, let’s dig into the classes of War of Rights!         When joining a server in War of Rights, you start out by selecting which faction you want to play as:         USA or CSA. After that you will be presented with the options above.         First you select which regiment you want to join. There will be regular infantry regiments and sharpshooter regiments.         Uniforms and weapon availability will depend on which regiment the player selects to join. ",
            "26/10 - 2015"
        ],
        [
            "Kickstarter Update 6: Collectors Edition",
            "Pages_FieldReports/KickstarterUpdate6/KickstarterUpdate6_thumb.jpg", "/KickstarterUpdate6",
            "Hello everyone! We're here today to give you a look at the content of the Collector's Edition         for War of Rights available from the Major - Physical Edition Reward Tier and higher,         and we also wanted to talk about the VERY Limited Physical Edition for War of Rights available at General of War and higher.         Before we get things started, we wanted to say that the images below are mock-ups         we wanted to share to give you an idea of what the contents might look like...         as well as one extra reward we're adding to all physical copies for War of Rights!         We love the American Civil War because of its great theme - it intrigues us.         We also love artifacts and items from the era because physical items helps people to",
            "28/10 - 2015"
        ],
        [
            "Kickstarter Update 7: Milestones", "Pages_FieldReports/KickstarterUpdate7/KickstarterUpdate7_thumb.jpg",
            "/KickstarterUpdate7",
            "Hello and welcome to the seventh Kickstarter update for War of Rights.         Before we dive into the update itself we wanted to share with you some very important milestones we've reached today!         We're now over 50% funded thanks to the support of over 1,300 backers. And to make today even better, we've also been approved on Steam Greenlight!         That means that all backers at Private or higher will be getting a Steam code for War of Rights once it's released.         But don't forget that if we don't make it to the goal here on Kickstarter then War of Rights won't get made!         This time we’ll be talking a bit about which pledge tiers grant access to the different early test versions of the game.         We have divided our testing phase into three different sections. ",
            "30/10 - 2015"
        ],
        [
            "Kickstarter Update 8: Spawn System", "Pages_FieldReports/KickstarterUpdate8/KickstarterUpdate8_thumb.jpg",
            "/KickstarterUpdate8",
            "Welcome to the eighth War of Rights Kickstarter update! Before we kick these off,         we’d like you all to please keep in mind that the mechanics are still very much a work in progress.         Things will get added, removed or completely overhauled as the development continues and we begin playtesting.         With that out of the way, let’s dig into the spawn system of War of Rights.         We’ve designed the spawn system of the game with a heavy emphasis on supporting prolonged group play in the best possible way.         We want players to be able to stay together with their regiment as much as possible during a match.         This means tackling the issue usually found in multiplayer games with respawns: a constant stream of freshly spawned players at the spawn point,         each spawning with very little delay after they have died, effectively splitting up the regiment after the first wipe.         To fix this, we’re opting to go with what we call a “base spawn wave” system.",
            "2/11 - 2015"
        ],
        [
            "Kickstarter Update 9: Movement System",
            "Pages_FieldReports/KickstarterUpdate9/KickstarterUpdate9_thumb.jpg", "/KickstarterUpdate9",
            "Welcome to a new Kickstarter update! Today we’ll talk about the movement system for War of Rights.         Please note that all animations shown below are work-in-progress and will get refined and reworked once we are funded and can continue to work on the game.         War of Rights will feature three stages of movement speeds: quick time (walk),         double quick (run) and charge (sprint). We are also going to support both right shoulder shift as well as shoulder arms stances in the game.         You'll also be able to kneel and fire for extra accuracy or, say, reload behind that safe looking snake rail fence.         Note that we’re only going to be allowing you to be stationary while kneeling since we’re not going to have any crouched type warfare in the game.",
            "4/11 - 2015"
        ],
        [
            "Kickstarter Update 10: Historical Accuracy",
            "Pages_FieldReports/KickstarterUpdate10/KickstarterUpdate10_thumb.jpg", "/KickstarterUpdate10",
            "Welcome to the tenth War of Rights Kickstarter update! This time, we’ll be talking a bit more in-depth about the work behind achieving as much historical accuracy as possible.         Hey there, this is Clark Morningstar (GeorgeCrecy), and I am Campfire Game's Historical Adviser.         If you haven't noticed already, we are committed to creating a great game.         One of the ways we are endeavoring to do so is by making sure that we are accurately         representing the period of the American Civil War through careful research and attention to detail.         When I joined on two years ago, it was my job to make sure that I had plenty of research material available for character artists",
            "6/11 - 2015"
        ],
        [
            "Kickstarter Update 11: Historical Accuracy",
            "Pages_FieldReports/KickstarterUpdate11/KickstarterUpdate11_thumb.jpg", "/KickstarterUpdate11",
            "Welcome to the second part of our of 'The Push for Historical Accuracy'!         We're now one week away from the end of the Kickstarter campaign for War of Rights, and we've managed to be over 70% funded!         We want to thank all of our backers for their support and their great comments.         And yes, we have been seeing how several of you have raised your pledge to Captain to get the Kickstarter exclusive Closed Alpha access,         as well as some of you going to Major - Physical and higher to get the exclusive Collector's Edition Boxed Set! We're         working hard to bring you daily updates during this final week, so be ready to learn a lot of information for War of Rights!         Before we dive right into the content for today's update we wanted to share the video below with you where Clark Morningstar (GeorgeCrecy)         discusses some of his work on the game while having fun with the interview (as you'll see!).",
            "7/11 - 2015"
        ],
        [
            "Kickstarter Update 12: Company Tools",
            "Pages_FieldReports/KickstarterUpdate12/KickstarterUpdate12_thumb.jpg", "/KickstarterUpdate12",
            'Hi! My name is Benjamin, but most of you know me as Hinkel,         and I am Campfire Game\'s Community Manager. I spent several years developing several free Civil War mods,         and one of my most successful is "North and South" for Mount and Blade. In this modification,         the community worked out a huge commanding system, based on player formed armies and regiments.         Each regiment consists of dozens of players, and some of those armies have several hundreds of players.         Looking at the huge amount of work those officers and generals have to organize those groups,         we figured that for War of Rights we wanted to help groups and offer them as many options and tools as possible!',
            "8/11 - 2015"
        ],
        [
            "Kickstarter Update 13: Weapon Features",
            "Pages_FieldReports/KickstarterUpdate13/KickstarterUpdate13_thumb.jpg", "/KickstarterUpdate13",
            "Welcome everyone to a new update! We wanted to get things started by letting you know that we're now over 74% funded thanks to the support of more than 1,600 backers!         We're moving closer to our main goal, and with five days left, every pledge matters!         We also want to thank those of you who have contacted us with words of encouragement as you raise your pledge so that War of Rights can be made!         This time we’ll be showcasing some of the cool weapon features in War of Rights.         Please remember that these are a work-in-progress, as has been the case for everything else we’ve shown thus far.         Back in the day, most of the weapons had adjustable sights where the soldier could set up the rifle to hit a target at a certain distance.         This made the rifle point upwards at a small angle, firing the bullet in an arc. ",
            "9/11 - 2015"
        ],
        [
            "Kickstarter Update 14: Audio", "Pages_FieldReports/KickstarterUpdate14/KickstarterUpdate14_thumb.jpg",
            "/KickstarterUpdate14",
            "Hello everyone! Allow me to introduce myself. My name is Tom Wright, and I am the Audio Lead for War of Rights.         I have over three years of professional experience in Game Audio and four titles shipped on Steam.         Before I dive right into this update, I want to take a moment to thank you to all for backing and spreading the word for this Kickstarter campaign!         Seeing this at over 78% funded with four days to go is very exciting and encouraging.        Audio is one of the key components used to bring video games to life. Without audio,         you no longer feel like you’re interacting with objects or people, and things feel far more artificial as a result.         My job on War or Rights is to produce all of the audio content, which involves field recording, sound effects design,         implementing the audio using Middleware (Wwise), producing the dialogue and mixing the final product.",
            "10/11 - 2015"
        ],
        [
            "Kickstarter Update 15: The Environment",
            "Pages_FieldReports/KickstarterUpdate15/KickstarterUpdate15_thumb.jpg", "/KickstarterUpdate15",
            "Welcome to the fifteenth Kickstarter update for War of Rights! We're very happy to report that         Veterans Day has been very good for the campaign since we're now 98% funded with 3 days to go!         We can't wait for this to catch (Exception) { } finally be funded so that we can work on our development schedule for         the game in order to have the Closed Alpha build ready within the next 6 months.         Now, let's get started with today's update!         Hi! I’m Emil Alexander Hansen, also known as Fancy Sweetroll. I studied art and computer graphics at 3D College in Denmark.         I am the creator of all the vegetation assets and I make sure the environment and the lighting looks as best as it possibly can.",
            "11/11 - 2015"
        ],
        [
            "Kickstarter Update 16: Funded", "Pages_FieldReports/KickstarterUpdate16/KickstarterUpdate16_thumb.jpg",
            "/KickstarterUpdate16",
            "It's been an excellent day for War of Rights, and thanks to over 100 backers who joined us today -         along with several of the other 1,700 backers we had before who raised their pledge -         we have catch (Exception) { } finally made it to the goal! We're thrilled about continuing to work on War of Rights to make it the best game it can be.         We want to say THANK YOU to all of you who believe in what we at Campfire Games want to do for War of Rights,         and we hope that you continue to spread the word because the more funds we can get, the more things we'll be able to do for the game!        We'll continue to do daily updates for the game up until the end of the campaign, so be ready for tomorrow's Kickstarter update!",
            "12/11 - 2015"
        ],
        [
            "Kickstarter Update 17: Stretch Goals",
            "Pages_FieldReports/KickstarterUpdate17/KickstarterUpdate17_thumb.jpg", "/KickstarterUpdate17",
            'After an amazing Veterans Day, we are happy to be back with a new project update to talk about something that a lot of backers have been asking us about... stretch goals!        We have several rather interesting elements we want to add to War of Rights if we can manage to secure enough funds to develop them,         such as an online drill camp area for your and your company to drill, discuss tactics or just goof around in.         Another stretch goal will allow us to expand the available uniforms in the game, adding more flair to the different regiments.         We’d also love to heavily expand our indoor props in order to create more "true to life" period rooms in our structures.         You can check our list of stretch goals in the image below. ',
            "12/11 - 2015"
        ],
        [
            "Kickstarter Update 18: Melee Combat",
            "Pages_FieldReports/KickstarterUpdate18/KickstarterUpdate18_thumb.jpg", "/KickstarterUpdate18",
            "Welcome to another War of Rights Kickstarter update! This time we’re going to be talking about the melee system         for the game and what we have planned for the different implementation phases.         But before we get started with today’s update, we wanted to talk about something we’ve been asked a lot about.         Now that the Kickstarter has reached its funding goal and that we’re in the final run to the end of our campaign,         we wanted to announce that we’ll also be taking pledges on our website with PayPal!         This is basically extension of this Kickstarter campaign so that we can aim at securing extra         funds from backers who don’t have a credit card or who didn’t get a chance to pledge while the Kickstarter was live.",
            "13/11 - 2015"
        ],
        [
            "Kickstarter Update 19: The Environment",
            "Pages_FieldReports/KickstarterUpdate19/KickstarterUpdate19_thumb.jpg", "/KickstarterUpdate19",
            "Welcome back for a new War of Rights Kickstarter update! I’m still Emil Alexander Hansen - also known as Fancy Sweetroll.         Its time to talk some more about the creation of the trees in War of Rights.         But before we get to that, I wanted to mention that along with our PayPal backers, we currently have almost £77,000 in funds!         That means we're close to the next stretch goal for more detailed interiors!         The workflow for creating trees is pretty much the same as when creating grass.         You start out by modelling the correct shape of an individual leaf from a specific species of tree, ",
            "14/11 - 2015"
        ],
        [
            "Kickstarter Update 20: Kickstarter funded",
            "Pages_FieldReports/KickstarterUpdate20/KickstarterUpdate20_thumb.jpg", "/KickstarterUpdate20",
            "After a month on Kickstarter, our campaign for War of Rights is now over and we'll get the funds needed to complete the game!         We want to thank all of you for your support because thanks to you we'll now be able to continue working on War of Rights!          We've also managed to reach one more stretch goal before the Kickstarter is over, so we now have three stretch goals down and three more to achieve!          We will continue to accept pledge on our PayPal page, and all funds we get there will still count towards the stretch goals!          If you know someone who didn't manage to pledge on the Kickstarter",
            "14/11 - 2015"
        ],
        [
            "Field Report 22: Pledge Raising Available", "Pages_FieldReports/FieldReport22/Fieldreport22_thumb.jpg",
            "/Fieldreport22",
            'We wanted to let everyone know that the Kickstarter funds have been collected and we’re currently busy transitioning from a         three year "spare time" project into one with funds behind it - all thanks to you, our wonderful backers!         We have just introduced an option for backers to raise their pledge if they either pledged on Kickstarter or on PayPal at our site at:         Simply press the big “RAISE PLEDGE” button and you’ll be asked to enter the email connected to the backing tool (Kickstarter or PayPal)         you used to back us. Once submitted, an email with further instructions will be sent to the email.         So if  payday has just passed and you have no clue what to spend all of that hard earned cash on,         like the gentlemen in the process of collecting it above, please consider raising your pledge! ',
            "08/12 - 2015"
        ],
        [
            "Field Report 23: Forum Badges", "Pages_FieldReports/FieldReport23/Fieldreport23_thumb.jpg",
            "/Fieldreport23",
            "Earlier today we sent out a survey to all of our Kickstarter backers asking for the email you wish us to send your digital     pledge rewards to as well as shipping details if you’ve pledged for any of our physical rewards. Please either check your     email associated with your Kickstarter account or log into Kickstarter in order to fill out the survey, thank you!     We’ve just enabled the forum badges obtained by backing us on either Kickstarter or via PayPal on our site.     In order to being able to select which forum badge you want to use, go to this link and follow the instructions:     You can change your forum rank at any time you want. To unlock new forum badges, all you need to do         is to raise your pledge. Note that forum badges only update once every hour so do not expect to     see any immediate change once you have submitted a newly selected forum badge.",
            "12/12 - 2015"
        ],
        [
            "Field Report 24: So long, 15!", "Pages_FieldReports/FieldReport24/Fieldreport24_thumb.jpg",
            "/Fieldreport24",
            "Hello everyone and welcome to this last field report of the year. We cannot wait to see what 2016 brings,     but before we talk more about that, we have a sneak peek as well as a website update to go through so     if you’re not too busy with the leftovers after Christmas feel free to join us!     First up, we have a bit of a sneak peek of a personal favorite of ours,     the Mississippi Rifle which we previously showed a render of has found its way in-game now.     We especially like the rather unique browned barrel and the iconic sword bayonet. Take a look!     We’ve just pushed an update to our website which enables all backers (Kickstarter & PayPal ones) to change their ",
            "26/12 - 2015"
        ],
        [
            "Field Report 25: The Black Hats!", "Pages_FieldReports/FieldReport25/Fieldreport25_thumb.jpg",
            "/Fieldreport25",
            "We hope you enjoyed the holidays and had a lovely New Year's Eve. We are back in business and used the time - among other things - to work on a new unit.      Instead of simple screenshots, we would like to introduce this unit in a more unique and cool way. For this,      we created a new series of short videos, which is called \"The Fighting Men of War of Rights\" Let's start with the first episode.      The Iron Brigade, which is also known as the Black Hat Brigade due to their black Hardee hats      was an elite infantry unit in the Army of the Potomac. It was composed of regiments from the Western states of Wisconsin, Michigan and Indiana.      During the war, the brigade suffered one of the highest casualty rates of any brigade.      During the Maryland campaign, the Iron Brigade consisted of the 2nd, 6th and 7th Wisconsin Infantry, as well as the 19th Indiana.",
            "29/1 - 2016"
        ],
        [
            "Field Report 26: Drill Camp", "Pages_FieldReports/FieldReport26/Fieldreport26_thumb.jpg", "/Fieldreport26",
            "Today, we have some exciting news as well as quite a lot of new content to show you all! Let's begin with an announcement.     We're pleased to announce the existence of our technical alpha \"Drill Camp\".     This early version of the drill camp - which was reached as a stretch goal during our crowdfunding campaign -     will be available for our captain tiered backers and upwards on Steam soon! Lower tiered backers will get access to the     Drill Camp whenever they get access to the game: Skirmishes phase 2, early access or release depending on their pledge tier.     The Drill Camp will feature a complete Civil War era army camp in a Maryland-esque setting,     full of forested areas as well as rolling countryside hills and fields for the players to explore together. ",
            "9/3 - 2016"
        ],
        [
            "Field Report 27: CSA Officers", "Pages_FieldReports/FieldReport27/Fieldreport27_thumb.jpg",
            "/Fieldreport27",
            "We're pleased to show you the Confederate officers in the latest episode of \"The Fighting Men of War of Rights\" which Hinkel,     our community manager has created using some of our game assets. The voice actor Samuel Hayes has graciously lent us his voice to the series of which we're grateful – thank you!     We're pleased to show you one of the very iconic Confederate sharpshooting rifles of the war, the Whitworth Rifle.     It was invented in England by Joseph Whitworth a few years prior to the war and a small number was bought by,     and imported to the Confederacy. The Whitworth rifle was similar in design to that of the Enfield but boasted polygonal rifling instead of the traditional rifling method.     This resulted in a smaller caliber but more accurate weapon due to the twist of the polygonal rifling.",
            "3/5 - 2016"
        ],
        [
            "Field Report 28: Drill Camp Released!", "Pages_FieldReports/FieldReport28/Fieldreport28_thumb.jpg",
            "/Fieldreport28",
            "Today, we're extremely happy and excited to announce the release of our technical alpha, the Drill Camp!     All Lieutenant Colonel tiered backers and higher will receive an email containing a key to activate on the digital distribution platform Steam     as well as a link to a walkthrough of how said activation is done – so keep an eye on your inbox and make sure to check your Junk/Spam folder too!     Backers pledging or raising their pledge to Lieutenant Colonel or higher will receive a key via email moments after their pledge has gone through our system.     Pledging can be done at the crowdfunding section of our website at: https://warofrights.com/Crowdfunding     A new hidden Alpha sub-forum has been added at: https://www.warofrightsforum.com/forum.php.     All forum profiles linked to pledge tiers at Lieutenant Colonel or higher have access to this new section of the forum. Here, you'll be able to post Alpha feedback,     submit bug reports or just talk about the Drill Camp activities in general. Once we broaden the access to the Drill Camp to more pledge tiers we will open up the Alpha sub-forum to those pledge tiers also.",
            "25/5 - 2016"
        ],
        [
            "Field Report 29: CSA Drill Camp Released!", "Pages_FieldReports/FieldReport29/Fieldreport29_thumb.jpg",
            "/Fieldreport29",
            "Today we're excited to be able to inform you, that the first big update to our technical alpha has been released!     The update more than doubles the playable area of the Drill Camp as well as adds the Confederate camp along with 6 playable Confederate regiments,     rebindable controls, an advanced options menu and a number of general improvements to enhance the user experience of the technical alpha.    Today, the rest of our alpha tier backers (Captains to Major - Physical Editions) will also be granted access,     so remember to check the emails used to back us with for an invitation! We've released about 10 updates since the     first wave got access to the technical alpha nearly two months ago.     These updates have mostly consisted of fixes of critical bugs and issues but have had some content     in them as well such as an overhaul of faces, several new weapons, new hair and facial hair",
            "25/7 - 2016"
        ],
        [
            "Field Report 30: Indie Fund & unit reveals", "Pages_FieldReports/FieldReport30/Fieldreport30_thumb.jpg",
            "/Fieldreport30",
            "A few weeks ago, Crytek launched their highly anticipated CRYENGINE Indie Development Fund which promises     to help out CRYENGINE game projects currently in development by partially funding them.     Three projects will be chosen to receive funding in each round.     The winning projects will be selected based on numbers of likes received by the community & by Crytek.     War of Rights is currently on a third place thanks to all of your votes - we'd love to get back on the first place though,     so we ask you all to please create an account and like War of Rights at:     https://www.cryengine.com/development-fund/projects/war-of-rights or by clicking the image above,     in order to up our chances of receiving additional funding which will allow us to put even more work and details into the game. ",
            "5/9 - 2016"
        ],
        [
            "Field Report 31: Company tool released!", "Pages_FieldReports/FieldReport31/Fieldreport31_thumb.jpg",
            "/Fieldreport31",
            "Today, we're bringing you a company focused field report since we've just released the very first iteration of our company tool.     The tool is being released with a 9 day testing period where we invite the community to try as many different features as possible and report any issues they might have.     All data will be wiped one final time once the testing period has ended (a countdown timer to this is being shown in the company tool).     Before we get to the new tool, let's talk a bit about what companies actually are and what they mean for War of Rights:     Companies are the player created groups that are so important for any multiplayer game in order for the community to thrive and overall teamwork to be enhanced.     In other games these groups are often known as either clans or guilds.     We've chosen the name company due to the unique regimental structure and authenticity our community is trying to replicate in their groups. ",
            "28/9 - 2016"
        ],
        [
            "Field Report 32: CE V upgrade released!", "Pages_FieldReports/FieldReport32/Fieldreport32_thumb.jpg",
            "/Fieldreport32",
            "We're extremely happy to announce that today marks the release of the next big milestone update to the Technical Alpha:     The game engine upgrade from CRYENGINE 3 to CRYENGINE V. We've spent these past few months of     the development with this upgrade in mind for our next big update to the game so we hope you'll like what you'll see.    But what exactly is and means an engine upgrade? How does it benefit the development of the game and thus also you, the players?    Ever since the first release of the Technical Alpha, we've been using the final CRYENGINE 3 version (at the time offered through Steam).     This version of the game engine is nearly a year old now and since Crytek, the creators of the engine, is one of the technological leaders of the industry",
            "22/10 - 2016"
        ],
        [
            "Field Report 33: Winter Drill Camp", "Pages_FieldReports/FieldReport33/Fieldreport33_thumb.jpg",
            "/Fieldreport33",
            "Today, we have just released the final content update of the year for the Technical Alpha: The Winter Edition! While we all wait on Skirmishes,     the first combat oriented test phase to arrive (more on that later) we thought some visual change would do our Technical Alpha testers good.     The entire playable drill camp areas have been updated in order to better reflect the season of the holidays.     This change is by no means considered by us as a “complete” graphical change from late summer to winter however -     it’s primarily meant as an event update and will soon enough make room for the standard drill camp.     The whole process was a relatively quick one - about 7 days of work for a couple of developers on the team. That being said,     the foundation laid by the work done will be able to be expanded upon should we ever cover engagements in the winter.",
            "15/12 - 2016"
        ],
        [
            "Field Report 34: User Interface", "Pages_FieldReports/FieldReport34/Fieldreport34_thumb.jpg",
            "/Fieldreport34",
            "Today, we’re pleased to give you a bit more of an insight regarding some of the content our first combat oriented test phase “Skirmishes” is set to include.     The user interface of the technical alpha has long been severely lacking in both functionality as well as its visual presentation.     With Skirmishes introducing the first actual game mode and thus likely is going to appeal to a somewhat broader audience,     we felt like this was the correct time to give the entirety of the user interface an overhaul.     Luckily, we had the great pleasure of welcoming Lee (fitting name if there ever was one!) to the team a few months ago as our new UI Artist.     He as well as Anthony, our UI Engineer and George, our Historical Advisor,     has been busy working on making the user experience a much better (and prettier one) in Skirmishes while maintaining quite a bit of authenticity. ",
            "1/3 - 2017"
        ],
        [
            "Field Report 35: Skirmishes Released!", "Pages_FieldReports/FieldReport35/Fieldreport35_thumb.jpg",
            "/Fieldreport35",
            "Today, we’re very excited to announce the release of Skirmishes Phase 1 - our first combat oriented test phase and also the move from Technical Alpha to Alpha!         It’s been a long time coming but it’s catch (Exception) { } finally here. We’d like to thank all of our backers and followers for the patience the vast majority of you have shown the past         several months. From today, Skirmishes Phase 1 will be available to all Captain tiered backers and higher.         Haven’t pledged yet? Our crowdfunding campaign is still up and running over at: https://warofrights.com/Crowdfunding         This first, and very much work in progress release of Skirmishes will feature three different Skirmish areas located on the Antietam battlefield         for you all to fight on! It features our very first gamemode (attack & defend with team tickets, base spawn waves & a round timer).",
            "18/5 - 2017"
        ],
        [
            "Field Report 36: Weekly Show & Musicians", "Pages_FieldReports/FieldReport36/FieldReport36_thumb.jpg",
            "/Fieldreport36",
            "More than a month since the release of our Skirmishes phase, we’d first like to thank everyone for your continued support.         It’s been amazing for us seeing the community at its finest during the sometimes intense battles in Skirmishes. Since the release of Skirmishes,         we have released 8 patches with numerous bug & visual fixes as well as released two additional skirmish areas. We will continue to work on stability,         balance & additional content throughout the alpha phase (more about the sixth one in this field report!).",
            "5/7 - 2017"
        ],
        [
            "Field Report 37: Uniforms & Harper's Ferry", "Pages_FieldReports/FieldReport37/FieldReport37_thumb.jpg",
            "/Fieldreport37",
            "Today, we’re here to show you all some sneak peaks of the uniforms available to the different pledge tiers via our crowdfunding campaign,         as well as give you a bit of an update regarding the next playable map: Harper’s Ferry!         Before we continue we’d like to remind everyone that, as everything else shown during the alpha, the content shown below is very much subject to change.        Harper’s Ferry has always been one of our most anticipated battle areas of the Maryland Campaign of 1862 to cover.         The towns unique position at the meeting place of the Shenandoah & Potomac rivers; its rich history including that of the US Armory,        and John Brown’s failed raid, which became the catalyst of the Civil War according to some",
            "23/8 - 2017"
        ],
        [
            "Field Report 38: CRYENGINE 5.4 Upgrade!", "Pages_FieldReports/FieldReport38/FieldReport38_thumb.jpg",
            "/Fieldreport38",
            "Today we’re pleased to be releasing the next major update of War of Rights. The update brings the alpha up to the newest version of CRYENGINE (5.4)         and introduces a number of bug fixes as well as backend improvements to various tools we use when developing the game.         An engine upgrade is not a small matter – everything from animations, sounds, networking, user interface,         spawn points and more has been affected by it in some form or another.We therefore urge all of our alpha testers to use our bug report section of the forum at",
            "15/12 - 2017"
        ],
        [
            "Field Report 39: Harper’s Ferry released!", "Pages_FieldReports/FieldReport39/FieldReport39_thumb.jpg",
            "/Fieldreport39",
            "Today, we’re happy to announce the release of Update 100 and with it the first release of the next map in line to be made available in War of Rights.         As Lee and his army were moving into Maryland, he found that there were several Union positions around him that still had garrisons,         most notably the important position of Harper's Ferry. On hearing about the Confederate invasion,         General McClellan was refused to pull back the Union garrisons by the General -in -Chief Henry Halleck,         which left General Dixon S Miles with a little more than 12, 000 men in the town of Harper's Ferry with only the orders to defend it as best he could. ",
            "25/03 - 2018"
        ],
        [
            "Field Report 40: Phase II Released!", "Pages_FieldReports/FieldReport40/FieldReport40_thumb.jpg",
            "/Fieldreport40",
            "Hello everyone and welcome back to our field report news segment - it’s most certainly been a while since our last one (6 months!) so we’re happy to be kicking things off with some exciting news indeed.         Before we go ahead we’d like to thank all of our backers and followers for allowing us to build War of Rights.This project would not have been possible without the financial support and willingness to alpha test provided by you.Thank you!         Lastly we’d like to remind you that the game is currently in its alpha phase and thus any presented features and mechanics are subject to change throughout the development of the game.         With that being said, let’s get into it!",
            "12/10 - 2018"
        ],
        [
            "Field Report 41: Early Access Roadmap", "Pages_FieldReports/FieldReport41/FieldReport41_thumb.jpg",
            "/Fieldreport41",
            "What a week it’s been! We’ve seen a lot of fresh recruits taking part in some top quality teamwork on the battlefields. We’d like to thank you all for choosing to support the development of War of Rights and welcome you to our great community!         This post is primarily to go through a few of the much reported issues by you all as well as what to expect in terms of new content going forward in this all-new Early Access alpha phase of War of Rights.         As most other alpha launches on Early Access, we have been running into several issues only really exposed by the increased number of active players during this first week on the platform.         We have already applied several hotfixes (drastically reducing load time, increasing the likelihood of the game shutting down properly upon exit and a much more stable server browser)",
            "11/12 - 2018"
        ],
        [
            "Field Report 42: Picket Patrol Released!", "Pages_FieldReports/FieldReport42/FieldReport42_thumb.jpg",
            "/Fieldreport42",
            "Hello everyone and welcome back to our field report news segment. The past 3 months following the Steam Early Access launch in early December have been extremely busy for us at Campfire Games.         We have released 16 alpha updates in the timeframe, focusing on many of the user reported issues such as long loading times, admin functionality, performance and stability issues, updates to the auto-ban system to weed out the worst team killers and much more.         While a great number of issues have been fixed there is also a great number of them remaining. We will continue to iron out bugs, work on performance optimizations and server stability throughout the development of the game.         Currently, we’re undertaking the big task of rewriting the code handling network connections in an effort to resolve connectivity issues.",
            "8/3 - 2019"
        ],
        [
            "Field Report 43: Artillery Progress Update", "Pages_FieldReports/FieldReport43/FieldReport43_thumb.jpg",
            "/Fieldreport43",
            "Today marks the 157th anniversary of the Battle of Antietam and we thought what better way to honor and remember the anniversary than to give you all an update on the progress of some of the most anticipated features of War of Rights currently in development!         We’re very excited to be detailing some of the progress we’re making regarding the implementation of the initial artillery system into the game as well as a small sneak peek about some very cool things to come in the time after the introduction of artillery.         One of our programmers, Michael will guide you through the progress below.",
            "17/9 - 2019"
        ],
        [
            "Update 166: Artillery - Released!", "Pages_FieldReports/Update166/Update166_thumb.jpg", "/Update166",
            "Today, we’re happy to announce the release of playable artillery onto the live build of the alpha! The artillery release is part of update 166 which is the largest update we have ever released for the game. We’re looking forward to be sharing its details with you below!         Before we get started, however, we’d like to thank everyone who’s helped us test out the features of the artillery in the public test branch of the game - we’ve been able to identify and fix a substantial amount of issues thanks to you all.         That being said, we do expect to see several new issues coming into view as we now begin mass testing on the live alpha build and so we look forward to seeing all of your feedback. ",
            "14/7 - 2020"
        ],
        [
            "Update 169: Platform System - Released!", "Pages_FieldReports/Update169/Update169_thumb.jpg", "/Update169",
            "Today marks yet another major milestone in the development of War of Rights as the long awaited platform system is released as part of update 169!          The platform system, having been in the works since January of 2018 is one of the biggest programming updates to the alpha we’ve ever done.         It is bound to change how a lot of the game features function on the backend due to its complexity and thus bugs should be expected in this very first deployment of it on the live alpha branch.",
            "1/12 - 2020"
        ]
    ]
}

function pageLoad() {
    try {
        clearTimeout(pageLoadingTimeout);
        document.getElementById("pageLoadingContainer").style.display = "none"
    } catch (n) {
    }
}

function ShowLoadingImage() {
    pageLoadingTimeout = setTimeout(function() {
            document.getElementById("pageLoadingContainer").style.display = "block"
        },
        500)
}

function getTimeRemaining(n) {
    var t = Date.parse(n) - Date.parse(new Date),
        i = Math.floor(t / 1e3 % 60),
        r = Math.floor(t / 6e4 % 60),
        u = Math.floor(t / 36e5 % 24),
        f = Math.floor(t / 864e5);
    return { total: t, days: f, hours: u, minutes: r, seconds: i }
}

function initializeClock() {
    var n, i;
    try {
        n = document.getElementById("companyToolCountdownTimer");

        function t() {
            var t = getTimeRemaining(deadline);
            t.total <= 0
                ? (n.style.lineHeight = "25px", n.style.marginTop = "3px", n.style.fontSize = "20px", n.innerHTML =
                    "Hold onto your hats gentlemen!")
                : n.innerHTML = t.days + ":" + t.hours + ":" + t.minutes + ":" + t.seconds
        }

        t();
        i = setInterval(t, 1e3)
    } catch (r) {
    }
}

function Loading(n) {
    try {
        document.getElementById("ContentPlaceHolder1_" + n).style.display = "block";
        var r = "lb" + n.replace("Loading", ""),
            t = document.getElementById("ContentPlaceHolder1_" + r),
            u = t.offsetWidth / 2 - loadingImageWidth / 2,
            f = t.offsetHeight / 2 - loadingImageWidth / 2,
            i = document.getElementById("ContentPlaceHolder1_" + n).style;
        i.marginLeft = u + "px";
        i.marginTop = f + "px";
        currentObject = n;
        spin = !0;
        LoadingSpin()
    } catch (e) {
    }
}

function LoadingSpin() {
    regimentRotation += 10;
    document.getElementById("ContentPlaceHolder1_" + currentObject).style.transform =
        "rotate(" + regimentRotation + "deg)";
    spin && setTimeout(LoadingSpin, 25)
}

function Loaded(n) {
    try {
        spin = !1;
        document.getElementById("ContentPlaceHolder1_" + n).style.display = "none"
    } catch (t) {
    }
}

function tbName1_changed() {
    tbName1 = document.getElementById("ContentPlaceHolder1_tbName1");
    tbName2 = document.getElementById("ContentPlaceHolder1_tbName2");
    tbName2.value = tbName1.value
}

function tbName2_changed() {
    tbName1 = document.getElementById("ContentPlaceHolder1_tbName1");
    tbName2 = document.getElementById("ContentPlaceHolder1_tbName2");
    tbName1.value = tbName2.value
}

function isNumberKey(n) {
    var t = n.which ? n.which : event.keyCode;
    return t > 31 && (t < 48 || t > 57) ? !1 : !0
}

var posters = [],
    images = 20,
    imagesContainerArray,
    currentImage = 1,
    player,
    thumbnails,
    galleryHeaderImages,
    galleryHeaderVideos,
    galleryHeaderBattlefieldMinutes,
    newsItems,
    descriptionLength = 550,
    pageLoadingTimeout,
    deadline = "October 7 2016 22:00:00 GMT+0200",
    regimentRotation = 0,
    currentObject,
    spin = !1,
    loadingImageWidth = 50,
    tbTown1,
    tbTown2,
    tbState1,
    tbState2,
    tbName1,
    tbName2