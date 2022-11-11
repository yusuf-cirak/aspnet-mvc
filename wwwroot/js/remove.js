function RemoveScript(){
    $(document).ready(function(){
        jQuery('#removeStudentCloseButton').click(function(){
            $('#removeModalLong').modal('hide')
        })


        $('[id*=btnDelete]').on('click',function(){
            var id=$(this).attr("name");
            var name=$('tr#'+id+' td')[0].innerText;


            $('input#DeleteId').val(id);
            $('strong#removeStudentName').text(name);


            $('#modalDeleteBtn').on('click',function(){
                $.ajax({
                    url:"/home/delete?id="+id,
                    type:"delete",
                    contentType:"application/json",
                    success:function(){

                        function closeModalAndRemoveInputs(){
                            $('#removeModalLong').modal('hide')

                        $('input#DeleteId').val("");

                        $('strong#removeStudentName').text("");

                        $('input#removeStudentText').text('');
                        }

                        setTimeout(removeStudent,2000);

                        function removeStudent(){
                            closeModalAndRemoveInputs();
                            $('tr#'+id).remove();
                            toastr.info("Öğrenci durumu başarıyla inaktif edildi")
                        }
                        
                    },
                    error:function(){
                        removeInputFields();
                        toastr.error("Öğrenciyi inaktif ederken bir problem oluştu!")

                    }
                })
            })


        })
    })

        
       
}

