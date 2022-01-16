$(document).ready(function () {

    /* DataTables start here. */

    $('#categoriesTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        buttons: [
            {
                text: 'Yenile',
                className: 'btn btn-warning',
                action: function (e, dt, node, config) {
                    $.ajax({
                        type: 'GET',
                        url: '/Planing/TaskPlanner/GetAllTaskPlan/',
                        contentType: "application/json",
                        beforeSend: function () {
                            $('#taskPlanTable').hide();
                            $('.spinner-border').show();
                        },
                        success: function (data) {
                            const taskPlanListDto = jQuery.parseJSON(data);
                            console.log(taskPlanListDto);
                            if (taskPlanListDto.ResultStatus === 0) {
                                let tableBody = "";
                                $.each(taskPlanListDto.TaskPlan.ToDoTasks.$values,
                                    function (index, toDoTask) {
                                        tableBody += `
                                                <tr>
                                    <td>${taskPlanListDto.TaskPlan.ID}</td>
                                    <td>${taskPlanListDto.TaskPlan.Name}</td>
                                    <td>${taskPlanListDto.TaskPlan.Description}</td>
                                    <td>${convertFirstLetterToUpperCase(taskPlanListDto.TaskPlan.IsActive.toString())}</td>
                                    <td>${convertToShortDate(taskPlanListDto.TaskPlan.StartDate)}</td>
                                    <td>${convertToShortDate(taskPlanListDto.TaskPlan.EndDate)}</td>
                                    <td>${taskPlanListDto.TaskPlan.TotalHour}</td>
                                    <td>${taskPlanListDto.TaskPlan.TotalWeek}</td>
                                    <td>${toDoTask.Developer.Name}</td>
                                    <td>${toDoTask.ExternalID}</td>
                                    <td>${toDoTask.Difficulty}</td>
                                    <td>${toDoTask.Duration}</td>
                                            </tr>`;
                                    });
                                $('#taskPlanTable > tbody').replaceWith(tableBody);
                                $('.spinner-border').hide();
                                $('#taskPlanTable').fadeIn(1400);
                            } else {
                                toastr.error(`${taskPlanListDto.Message}`, 'İşlem Başarısız!');
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            $('.spinner-border').hide();
                            $('#taskPlanTable').fadeIn(1000);
                            toastr.error(`${err.responseText}`, 'Hata!');
                        }
                    });
                }
            }
        ],
        language: {
            "sDecimal": ",",
            "sEmptyTable": "Tabloda herhangi bir veri mevcut değil",
            "sInfo": "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
            "sInfoEmpty": "Kayıt yok",
            "sInfoFiltered": "(_MAX_ kayıt içerisinden bulunan)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Sayfada _MENU_ kayıt göster",
            "sLoadingRecords": "Yükleniyor...",
            "sProcessing": "İşleniyor...",
            "sSearch": "Ara:",
            "sZeroRecords": "Eşleşen kayıt bulunamadı",
            "oPaginate": {
                "sFirst": "İlk",
                "sLast": "Son",
                "sNext": "Sonraki",
                "sPrevious": "Önceki"
            },
            "oAria": {
                "sSortAscending": ": artan sütun sıralamasını aktifleştir",
                "sSortDescending": ": azalan sütun sıralamasını aktifleştir"
            },
            "select": {
                "rows": {
                    "_": "%d kayıt seçildi",
                    "0": "",
                    "1": "1 kayıt seçildi"
                }
            }
        }
    });

    /* DataTables end here */

    
});