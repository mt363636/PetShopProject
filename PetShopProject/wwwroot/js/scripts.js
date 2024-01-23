$(document).ready(function () {
    $('.show-comments').on('click', function () {
        var animalId = $(this).data('animal-id');
        toggleComments(animalId);
    });

    // Event delegation for dynamically added .show-all elements
 

    function toggleComments(animalId) {
        var commentsContainer = $("#comments-" + animalId);
        var showLabel = $("label.show-comments[data-animal-id='" + animalId + "']");
        commentsContainer.slideToggle();
        showLabel.toggleClass("expanded");
    }



});
