document.addEventListener('DOMContentLoaded', function () {
    var connection = new signalR.HubConnectionBuilder().withUrl('product').build();
    let btnSave = document.getElementById('btnSave');
    btnSave.disabled = true;

    connection.on('receiveProduct', function (name, description, status, actionType) {

    });

    connection.start().then(function () {
        btnSave.disabled = false;
    }).catch(function (err) {

        return console.error(err.toString());
    });

    btnSave.addEventListener('click', function (e) {
        let name = document.getElementById('txtName').value;
        let description = document.getElementById('txtdescription').value;
        let status = document.getElementById('ddStatus').value;

        connection.invoke('sendProduct', name, description, status, 'create')
            .catch(function (err) {
                return console.error(err.toString());
            });
        e.preventDefault();
    });
});
