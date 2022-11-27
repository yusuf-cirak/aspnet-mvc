        function CreateScript(){
            $(document).ready(function(){
            
                $('#createForm').submit(function(e){
                    e.preventDefault();
                    var hobbyIds=[];
                                            var selectedHobbyNames=$('#create-multiple-checkboxes option:selected');
                                            $(selectedHobbyNames).each(function(i,e){
                                                hobbyIds.push(selectedHobbyNames[i].value);
                                            })
                                            if($('#CreateFullName').val()=='' || hobbyIds.length==0){
                                                toastr.warning('Lütfen alanları doldurunuz!')
                                                return;
                                            }
                                            
    
    
                    var studentData={
                                                id:$('input#CreateId').val(),
                                                fullName:$('#CreateFullName').val(),
                                                departmentId:$('select#CreateDepartmentId').val(),
                                                hobbyIds:hobbyIds,
                                                classTeacherId:$('select#CreateClassTeacherId').val(),
                                                mentorTeacherId:$('select#CreateMentorTeacherId').val()
                                            }
    
                                           
    
    
                                            jsonData=JSON.stringify(studentData);
                                            $.ajax({
                                                method:"post",
                                                contentType:'application/json; charset=utf-8',
                                                dataType:"html",
                                                data:jsonData,
                                                url:"/home/create",
                                                cache:false,
                                                success: function (res) {
                                                    setTimeout(addStudentToTable,2000);

                                                    function addStudentToTable(){

                                                        $(selectedHobbyNames).each(function(i){
                                                            $(this).prop('selected',false)
                                                        })


                                                        $('input#CreateId').val('');
                                                        $('input#CreateFullName').val('');
                                                        $('input#CreateFullName').val('');


                                                        var student=JSON.parse(res);
                                                    console.log(student);
                                                    var studentHobbiesArr=student.hobbies;
                                                    var studentHobbiesStr="";
                                                    for(var i=0;i<studentHobbiesArr.length;i++){
                                                        if(i!=studentHobbiesArr.length-1){
                                                            studentHobbiesStr+=studentHobbiesArr[i].name+", "
                                                        }
                                                        else{
                                                            studentHobbiesStr+=studentHobbiesArr[i].name;
                                                        }
                                                    }
    
                                                    $('#exampleModalLong').modal('hide');
    
                                                    var raw=`<tr id="`+student.id+`"><td id="formStudentFullName" class="sorting_1">`+student.fullName+`</td>`+
                                                        `<td id="formStudentDepartmentName">`+student.department.name+`</td>`+
                                                         `<td id="formStudentHobbies">`+studentHobbiesStr+`</td>`+
                                                         `<td id="formStudentClassTeacherName">`+student.classTeacher.fullName+`</td>`+
                                                         `<td id="formStudentMentorTeacherName">`+student.mentorTeacher.fullName+`</td>`+
                                                         `<td id="formStudentOperation"><a id="btnDetails" name="`+student.id+`" class="btn btn-info">Güncelle</a>`+
                                                         `<a id="btnDelete" data-bs-toggle="modal" data-bs-target="#removeModalLong" name="`+student.id+`" class="btn btn-danger">Sil</a> </td>`+`</tr>`
    
    
                                                    $('table#myTable tbody').append(raw);
    
                                                    $('div.list-partial').trigger('change');
    
                                                        toastr.success("Öğrenci başarıyla eklendi!");
                                                    }
                                                    },
                                                    error: function () {
                                                        toastr.error("Öğrenci verisi eklenirken bir sorun oluştu");     
    
                                                    }
    
                                            })
    
                })
    
    
                jQuery('button#createModalClose').click(function(){
                    $('#exampleModalLong').modal('hide')
                })
            })
        }
       
