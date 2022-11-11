function EditScript(){
    var inputFullName=$('input#EditFullName');
    var departmentSelects=$('select#EditDepartmentId option')
   var classTeacherSelects=$('select#EditClassTeacherId option')
    var mentorTeacherSelects=$('select#EditMentorTeacherId option')
   var hobbyMultipleSelects=$('#edit-multi-select-hobby option')


    // update student fields by clicking details button
       $(document).ready(function (){
           $('[id*=btnDetails]').on('click', function () {
   $.ajax({
url: '/home/edit',
dataType: "html",
data: { "id": $(this).attr('name') },
type: "GET",
contentType: "application/json",
success: function (response) {
   response=JSON.parse(response);

   $(`#edit-multi-select-hobby option:selected`).each(function(){
       $(this).prop('selected',false)
   })


    $('input#EditId').attr('value',response.id);


    inputFullName.removeAttr('readonly');

    inputFullName.val(response.fullName)
    

    $(departmentSelects).each(function(i){
       $(departmentSelects)[i].removeAttribute('hidden')
       $(departmentSelects)[i].removeAttribute('disabled')

    })

   var selectedDepartment=$("select#EditDepartmentId option[value="+response.departmentId+"]").val();
   $('select#EditDepartmentId').val(selectedDepartment)

    $(classTeacherSelects).each(function(i){
       $(classTeacherSelects)[i].removeAttribute('hidden')

       $(classTeacherSelects)[i].removeAttribute('disabled')

    })
   var selectedClassTeacher=$("select#EditClassTeacherId option[value="+response.classTeacherId+"]").val();
   $('select#EditClassTeacherId').val(selectedDepartment)


    $(mentorTeacherSelects).each(function(i){
       $(mentorTeacherSelects)[i].removeAttribute('hidden')
       $(mentorTeacherSelects)[i].removeAttribute('disabled')
    })
    
   var selectedMentorTeacher=$("select#EditMentorTeacherId option[value="+response.mentorTeacherId+"]").val();
   $('select#EditMentorTeacherId').val(selectedMentorTeacher)

    $(hobbyMultipleSelects).each(function(){
       $(this).removeAttr('hidden')
       $(this).removeAttr('disabled')
    })


     $(response.hobbies).each(function(i){
       $(`#edit-multi-select-hobby option[value="`+response.hobbies[i].id+`"]`).prop('selected',true)
    })



   $('#editBtn').removeAttr('disabled')

   },
   error: function (err) {
   toastr.error(err.responseText);
}
})

});
});



       var formInputsChanged = false;

       $(document).ready(function () {
           $('input, select').change(function () {
               formInputsChanged = true;
           })
       })

       $(document).ready(function(){
           $('#editBtn').click(function(e){
               e.preventDefault();
               if(formInputsChanged){
                   var hobbyIds=[];
                   var selectedHobbyNames=$('#edit-multi-select-hobby option:selected');
                   $(selectedHobbyNames).each(function(i,e){
                       hobbyIds.push(selectedHobbyNames[i].value);
                   })


                   var studentData={
                       id:$('input#EditId').val(),
                       fullName:$('#EditFullName').val(),
                       departmentId:$('select#EditDepartmentId').val(),
                       hobbyIds:hobbyIds,
                       classTeacherId:$('select#EditClassTeacherId').val(),
                       mentorTeacherId:$('select#EditMentorTeacherId').val()
                   }

    inputFullName.attr('readonly')
    inputFullName.attr("value","")
    inputFullName.val("")

       $('#editBtn').attr('disabled','true')




    $(departmentSelects).each(function(i){
       $(departmentSelects)[i].setAttribute('hidden','true')
       $(departmentSelects)[i].setAttribute('disabled','true') 

    })

    $('select#EditDepartmentId').val('')

    $(classTeacherSelects).each(function(i){
       $(classTeacherSelects)[i].setAttribute('hidden','true')
       $(classTeacherSelects)[i].setAttribute('disabled','true')

    })
    $('select#EditClassTeacherId').val('')


     $(mentorTeacherSelects).each(function(i){
       $(mentorTeacherSelects)[i].setAttribute('hidden','true')
       $(mentorTeacherSelects)[i].setAttribute('disabled','true')
    })
    $('select#EditMentorTeacherId').val('')

     $(hobbyMultipleSelects).each(function(i){
       $(hobbyMultipleSelects)[i].setAttribute('hidden','true')
       $(hobbyMultipleSelects)[i].setAttribute('disabled','true')
       $(hobbyMultipleSelects)[i].setAttribute('selected','false')
    })

    studentData=JSON.stringify(studentData);
                    console.log(studentData)

                       $.ajax({
                           url: "/home/edit",
                           type: "put",
                           dataType: "json",
                           contentType: "application/json; charset=utf-8",
                           data: studentData,
                           success: function (res) {
                               var studentHobbiesArr=res.hobbies;
                           var studentHobbiesStr="";
                           for(var i=0;i<studentHobbiesArr.length;i++){
                               if(i!=studentHobbiesArr.length-1){
                                   studentHobbiesStr+=studentHobbiesArr[i].name+", "
                               }
                               else{
                                   studentHobbiesStr+=studentHobbiesArr[i].name;
                               }
                           }
                               var tableRows=$('tr#'+res.id+' td');

                               tableRows[0].innerText=res.fullName;
                               tableRows[1].innerText=res.department.name;
                               tableRows[2].innerText=studentHobbiesStr;
                               tableRows[3].innerText=res.classTeacher.fullName;
                               tableRows[4].innerText=res.mentorTeacher.fullName;

                               toastr.success("Öğrenci güncellendi!");     


                           },
                           error: function () {
                               toastr.error("Öğrenci verisi güncellenirken bir sorun oluştu");     

                           }
                       }); 
               }

               else toastr.warning("Herhangi bir değişiklik yapmadınız, lütfen bir değişiklik yaptıktan sonra butona tıklayınız!")
           })
       })

}
                         
                        