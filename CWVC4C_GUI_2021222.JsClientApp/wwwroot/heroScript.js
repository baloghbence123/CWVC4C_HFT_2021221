let heroes = [];
let connection = null;
getdata();
setupSignalR();
let heroIdtoUpdate = -1;


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:29868/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();
    connection.on("HeroCreated", (user, message) => {
        getdata();
    });
    connection.on("HeroDeleted", (user, message) => {
        getdata();
    });
    connection.on("HeroUpdated", (user, message) => {
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
    await fetch('http://localhost:29868/hero')
        .then(x => x.json())
        .then(y => {
            heroes = y;
            console.log(heroes);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    heroes.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.heroId + "</td><td>" + t.name + "</td><td>" + t.attackPower + "</td><td>" + t.defensePower + "</td><td>"
        + t.elementId + "</td><td>"+ `<button type="button" onclick="Remove(${t.heroId})">Delete</button>`
        + `<button type="button" onclick="showUpdate(${t.heroId})">Update</button>`

            +"</td></tr>";
        console.log(t.name);
    });
}

function createEl() {
    let name = document.getElementById('heroname').value;
    let pwr = document.getElementById('heropwr').value;
    let def = document.getElementById('herodef').value;
    let elid = document.getElementById('heroeselementid').value;



    fetch('http://localhost:29868/hero', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify({ name: name, attackPower: pwr, defensePower: def, elementId: elid }),
    }).then(response => response).then(data => {
        console.log('Succes: ', data);
        getdata();
    }).catch((error) => { console.error('Error: ', error); });
    
    
}

function Remove(id) {
    fetch('http://localhost:29868/hero/' + id, {
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
    var newHero = heroes.find(t => t['heroId'] == id);
    

    document.getElementById('heronametoupdate').value = newHero.name;
    document.getElementById('heropwrtoupdate').value = newHero.attackPower;
    document.getElementById('herodeftoupdate').value = newHero.defensePower;
    document.getElementById('heroeselementidtoupdate').value = newHero.elementId;
    
        
    document.getElementById('updateformdiv').style.display = 'flex';
    heroIdtoUpdate = id;
}

function updateEl() {
    document.getElementById('updateformdiv').style.display = 'none'
    let name = document.getElementById('heronametoupdate').value;
    let pwr = document.getElementById('heropwrtoupdate').value;
    let def = document.getElementById('herodeftoupdate').value;
    let elid = document.getElementById('heroeselementidtoupdate').value;

    
    fetch('http://localhost:29868/hero', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify({ heroId: heroIdtoUpdate, name: name, attackPower: pwr, defensePower: def, elementId: elid }),
    }).then(response => response).then(data => {
        console.log('Succes: ', data);
        getdata();
    }).catch((error) => { console.error('Error: ', error); });


}