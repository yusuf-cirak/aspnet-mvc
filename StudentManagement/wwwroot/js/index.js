function IndexScript(){
    // jQuery is not working in partial views when not rendered, i render partial view on init with empty model.
    $(document).ready(function () {
        $.ajax({
                url: '/home/getcreateorupdatepartial',
                type: "GET",
                dataType: "html",
                data:{"partialName":"Create"},
                contentType:"application/html charset=utf-8",
                success: function (response) {
                    $('.create-partial').html(response)             
                },
                error: function (err) {
                    toastr.error("Beklenmedik bir sorun oluştu!")
                }
            })


        $.ajax({
                url: '/home/getstudents',
                type: "GET",
                dataType: "html",
                data:{},
                contentType:"application/html charset=utf-8",
                success: function (response) {
                    $('.list-partial').html(response)
                },
                error: function () {
                    toastr.error("Beklenmedik bir durum oluştu!")
                }
            });



                $.ajax({
                    url: '/home/getcreateorupdatepartial',
                type: "GET",
                dataType: "html",
                data:{"partialName":"Edit"},
                contentType:"application/html charset=utf-8",
                success: function (response) {
                    $('.update-partial').html(response);
                },
                error: function () {
                    toastr.error("Bir şeyler ters gitti!")
                }
            })


            $('div.list-partial').change(function(){
                EditScript();
                
                RemoveScript();
            })

            
        })
}
        
        