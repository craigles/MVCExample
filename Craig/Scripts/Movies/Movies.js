$(function() {
    $('.movie-row').click(function () {
        $.ajax({
            url: '_Movie',
            data: { movieId: $(this).attr('id') },
            success: function(data) {
                alert(data);
            }
        });
    });
});