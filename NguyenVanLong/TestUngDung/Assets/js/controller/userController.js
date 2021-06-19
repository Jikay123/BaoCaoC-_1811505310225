var user = {
    init: function () {
        user.registerEvent();
    },
    registerEvent: function () {
        $('.status').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this)
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/User/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type="POST",
                success: function (response) {
                    console.log(response);
                    if (response.Status == "activate") {
                        btn.text('activate');
                    } else {
                        btn.text('blocked')
                    }
                }
            })

        });
    },
    reload: function () {
        $('.status').on('click').
    }

    
}