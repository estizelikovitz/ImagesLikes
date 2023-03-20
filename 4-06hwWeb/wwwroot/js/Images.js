$(() => {
    loadImages();

    function loadImages() {
        $.get('/home/getall', function (images) {
            //$(".main").remove();
                images.forEach(image => {
                $(".main").append(`<div class="row">
                                        <div class="col-md-8 offset-md-2">
                                            <div class="jumbotron" style="margin-bottom: 20px; text-align: center;">
                                                <a href="/home/viewimage?id=${image.id}">
                                                    <h3>${image.title}</h3>
                                                    <h5>Uploaded at: ${image.dateCreated}</h5>
                                                    <img style="width: 400px;" src="/uploads/${image.imageSource}" />
                                                </a>
                                            </div>
                                        </div>
                                    </div>`);

            });
        });
    }

    //$("#upload").on('click', function () {
    //    const title = $("#title").val();
    //    const imageFile = $("#img").val();

    //    $.post('/home/uploads', { title, imageFile }, function () {
    //        loadPeople();
    //        $("#title").val('');
    //        $("#img").val('');
    //    });
    //});

});