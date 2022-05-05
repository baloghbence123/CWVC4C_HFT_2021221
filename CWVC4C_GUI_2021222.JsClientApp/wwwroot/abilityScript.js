let abilities = [];
let connection = null;
getdata();
setupSignalR();
let abilityIdtoUpdate = -1;


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:29868/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();
    connection.on("AbilityCreated", (user, message) => {
        getdata();
    });
    connection.on("AbilityDeleted", (user, message) => {
        getdata();
    });
    connection.on("AbilityUpdated", (user, message) => {
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
    await fetch('http://localhost:29868/ability')
        .then(x => x.json())
        .then(y => {
            abilities = y;
            console.log(abilities);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    abilities.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.abilityId + "</td><td>" + t.name + "</td><td>" + t.manaCost + "</td><td>" + t.dmg + "</td><td>"
        + t.heroId + "</td><td>" + `<button type="button" onclick="Remove(${t.abilityId})">Delete</button>`
        + `<button type="button" onclick="showUpdate(${t.abilityId})">Update</button>`

            + "</td></tr>";
        console.log(t.name);
    });
}

function createEl() {
    let name = document.getElementById('abilityname').value;
    let mana = document.getElementById('abilitymana').value;
    let pwr = document.getElementById('abilitypwr').value;
    let heid = document.getElementById('abilityelementid').value;



    fetch('http://localhost:29868/ability', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify({ name: name, manaCost: mana, dmg: pwr, heroId: heid }),
    }).then(response => response).then(data => {
        console.log('Succes: ', data);
        getdata();
    }).catch((error) => { console.error('Error: ', error); });


}

function Remove(id) {
    fetch('http://localhost:29868/ability/' + id, {
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
    var newAbility = abilities.find(t => t['abilityId'] == id);


    document.getElementById('abilitynametoupdate').value = newAbility.name;
    document.getElementById('abilitymanatoupdate').value = newAbility.manaCost;
    document.getElementById('abilitypwrtoupdate').value = newAbility.dmg;
    document.getElementById('abilityelementidtoupdate').value = newAbility.heroId;


    document.getElementById('updateformdiv').style.display = 'flex';
    abilityIdtoUpdate = id;
}

function updateEl() {
    document.getElementById('updateformdiv').style.display = 'none'


    let name = document.getElementById('abilitynametoupdate').value;
    let mana = document.getElementById('abilitymanatoupdate').value;
    let dmg = document.getElementById('abilitypwrtoupdate').value;
    let heid = document.getElementById('abilityelementidtoupdate').value;

    fetch('http://localhost:29868/ability', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify({ abilityId: abilityIdtoUpdate, name: name, manaCost: mana, dmg: dmg, heroId: heid }),
    }).then(response => response).then(data => {
        console.log('Succes: ', data);
        getdata();
    }).catch((error) => { console.error('Error: ', error); });


}