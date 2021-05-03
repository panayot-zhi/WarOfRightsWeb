
function isValidDate(d) {
    return d instanceof Date && !isNaN(d);
}

function calculateDates() {
    var dateFields = $(".local-date").text();

    for (var dateField in dateFields) {
        var date = new Date(dateField);
        if (!isValidDate(date)) {
            continue;
        }

        // TODO
    }
}
