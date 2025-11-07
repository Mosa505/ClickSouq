var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/Admin/Company/GetAll' },
        "columns": [
            { data: 'name', "width": "20%" },
            { data: 'streetAddress', "width": "10%" },
            { data: 'city', "width": "15%" },
            { data: 'state', "width": "10%", },
            { data: 'postalCode', "width": "15%" },
            { data: 'phoneNumber', "width": "15%" },
            
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                     <a href="/admin/Company/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Edit</a>               
                     <a OnClick=Delete('/admin/Company/Delete/${data}') class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Delete</a>
                    </div>`
                },
                "width": "10%"

            }


        ]
    });
}