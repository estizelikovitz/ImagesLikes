$(() => {
    $('#like-button').on('click', function () {
        const id = $(this).data('id');

        $.post(`/home/likes`, { id }, function () {
            $("#like-button").prop('disabled', true);
        })
    });

    setInterval(() => {
        const id = $("#image-id").val();
        $.get(`/home/getlikes`, { id }, function (likes) {
            $("#likes-count").text(likes);
        })
    }, 500)
});
