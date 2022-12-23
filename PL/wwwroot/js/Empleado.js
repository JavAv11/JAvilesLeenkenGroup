<reference path="Empleado.js"/>

$(document).ready(function () {
    GetAll();
    Empleado();

});

function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5254/api/Empleado/GetAll',
        success: function (result) {
            $('#Empleados tbody').empty();
            $.each(result.Objects, function (i, Empleado) {
                var filas =
                    '<tr>' +
                    '<td class="text-center">' +
                    '<a href="#" onclick=GetById(' + Empleado.IdEmpleado + ')">' +
                    '<img  style="height: 25px; width: 25px;" src="../img/edit.ico" />' +
                    '</a>' +
                    '</td>'
                    + "<td  id='id' class='text-center'>" + Empleado.IdEmpleado + "</td>"
                    + "<td class='text-center'>" + Empleado.Nombre + "</td>"
                    + "<td class='text-center'>" + Empleado.ApellidoPaterno + "</ td>"
                    + "<td class='text-center'>" + Empleado.ApellidoMaterno + "</ td>"
                    + "<td class='text-center'>" + Empleado.NumeroNomina + "</ td>"
                    + "<td class='text-center'>" + Empleado.Estado.IdEstado + "</td>" +
                    '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + Empleado.IdEmpleado + ')"><span class="glyphicon glyphicon-trash" style="color:#FFFFFF"></span></button></td>'
                    + "</tr";
                $("#Empleados tbody").append(filas);
            });
        },
        error: function (result) {
            alert('Error en la consulta' + result.responseJSON.ErrorMessage);
        }
    });
}