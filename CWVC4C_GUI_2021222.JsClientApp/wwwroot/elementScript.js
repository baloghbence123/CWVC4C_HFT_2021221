let elements = [];
let connection = null;
getdata();
setupSignalR();
let elementIdToUpdate = -1;


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:29868/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();
    connection.on("ElementCreated", (user, message) => {
        getdata();
    });
    connection.on("ElementDeleted", (user, message) => {
        getdata();
    });
    connection.on("ElementUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:29868/element')
        .then(x => x.json())
        .then(y => {
            elements = y;
            console.log(elements);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    elements.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.elementId + "</td><td>" + t.name
            + "</td><td>" + `<button type="button" onclick="Remove(${t.elementId})">Delete</button>`
            +`<button type="button" onclick="showUpdate(${t.elementId})">Update</button>`
            +"</td></tr>";
        console.log(t.name);
    });
}

function createEl() {
    let name = document.getElementById('elementname').value;
    fetch('http://localhost:29868/element', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify({ name: name }),
    }).then(response => response).then(data => {
        console.log('Succes: ', data);
        getdata();
    }).catch((error) => { console.error('Error: ', error); });
    
    
}

function Remove(id) {
    fetch('http://localhost:29868/element/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}
function showUpdate(id) {
    document.getElementById('heronametoupdate').value = elements
        .find(t => t['HeroId'] == id)['name'];
    document.getElementById('updateformdiv').style.display = 'flex';
    elementIdToUpdate = id;
}

function updateEl() {
    document.getElementById('updateformdiv').style.display = 'none'
    let name = document.getElementById('elementnametoupdate').value;
    
    fetch('http://localhost:29868/element', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify({ elementId: elementIdToUpdate, name: name }),
    }).then(response => response).then(data => {
        console.log('Succes: ', data);
        getdata();
    }).catch((error) => { console.error('Error: ', error); });


}