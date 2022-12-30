$(document).ready(function () { 
    GetAll();
    EstadoGetAll();

});

function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5254/api/Empleado/GetAll',
        success: function (result) {
            $('#tblEmpleado tbody').empty();
            $.each(result.objects, function (i, empleado) {
                var filas =
                    '<tr>'
                    + '<td class="text-center">'
                    + '<a class="btn btn-warning glyphicon glyphicon-edit" onclick="GetById(' + empleado.idEmpleado + ')">'
                    + '</a> '
                    + '</td>'
                    + "<td  id='IdEmpleado' class='text-center'>" + empleado.idEmpleado + "</td>"
                    + "<td  class='text-center'>" + empleado.nombre + "</td>"
                    + "<td class='text-center'>" + empleado.apellidoPaterno + "</ td>"
                    + "<td  class='text-center'>" + empleado.apellidoMaterno + "</ td>"
                    + "<td  class='text-center'>" + empleado.numeroNomina + "</ td>"
                    + "<td  class='text-center'>" + empleado.estado.idEstado + "</td>" 
                    + "<td  class='text-center'>" + empleado.estado.nombre + "</td>"+
                    '<td class="text-center"> <button class="btn btn-danger" onclick="Delete(' + empleado.idEmpleado + ')"><span class="glyphicon glyphicon-trash" style="color:#FFFFFF"></span></button></td>'
                    + "</tr";
                $("#tblEmpleado tbody").append(filas);
            });
        },
        error: function (result) {
            alert('Error en la consulta' + result.responseJSON.ErrorMessage);
        }
    });
}

function Add(empleado) {
    $.ajax({
        type: 'POST',
        url: 'http://localhost:5254/api/Empleado/Add',
        dataType: 'json',
        data: empleado,
        data: JSON.stringify(empleado),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            
            $('#ModalForm').modal('hide');
            $('myModal').modal();
            GetAll();
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
}

function Update(empleado) {

    $.ajax({
        type: 'POST',
        url: 'http://localhost:5254/api/Empleado/Update',
        datatype: 'json',
        data: JSON.stringify(empleado),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            $('#myModal').modal();
            $('#ModalUpdate').modal('hide');
            GetAll();
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });

};

function Delete(idEmpleado) {

    if (confirm("¿Estas seguro de eliminar el empleado seleccionado?")) {
        $.ajax({
            type: 'DELETE',
            url: 'http://localhost:5254/api/Empleado/Delete/' + idEmpleado,
            success: function (result) {
                $('#myModal').modal();
                GetAll();
            },
            error: function (result) {
                alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
            }
        });

    };
};

function ShowModal() {
    $('#ModalForm').modal('show');
}
function HideModal() {
    $('#ModalForm').modal('hide');
}


function Save() {
    var empleado = {
        idEmpleado: $('#txtIdEmpleado').val(),
        numeroNomina: '',
        nombre: $('#txtNombre').val(),
        apellidoPaterno: $('#txtApellidoPaterno').val(),
        apellidoMaterno: $('#txtApellidoMaterno').val(),
        estado: {
            idEstado: $('#txtEstado').val(),
            nombre: '',
            estados:[]
        },
        empleados:[]
    }
    if ($('#txtIdEmpleado').val() == "") {
        empleado.idEmpleado=0,
        Add(empleado);
    }
    else {
        Update(empleado);
    }
}

function EstadoGetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5254/api/Empleado/GetAll',
        success: function (result) {
            $("#ddlEstado").append('<option value="' + 0 + '">' + 'Seleccione una opción' + '</option>');
            $.each(result.Objects, function (i, estado) {
                $("#ddlEstado").append('<option value="'
                    + estado.IdEstado + '">'
                    + estado.Nombre + '</option>');
            });
        }
    });
}

function GetById(idEmpleado) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5254/api/Empleado/GetById/' + idEmpleado,
        success: function (result) {
            $('#txtIdEmpleado').val(result.object.idEmpleado);
            $('#txtNombre').val(result.object.nombre);
            $('#txtApellidoPaterno').val(result.object.apellidoPaterno);
            $('#txtApellidoMaterno').val(result.object.apellidoMaterno);
            $('#txtNumeroNomina').val(result.object.numeroNomina);
            $('#txtEstado').val(result.object.estado.idEstado);

            $('#ModalForm').modal('show');
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }


    });
}