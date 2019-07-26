const urls = {
    base : 'https://baas.kinvey.com/',
    calendar : 'rpc/kid_BJ_Ke8hZg/custom/calendar?query=',
    venues : 'appdata/kid_BJ_Ke8hZg/venues/'
}

const kinveyCredentials = {
    appID: 'kid_BJ_Ke8hZg',
    user: 'guest',
    password: 'pass'
}

const base_64 = btoa(`${kinveyCredentials.user}:${kinveyCredentials.password}`);

const headers = {
    'Authorization' : `Basic ${base_64}`,
    'Content-type' : 'application/json'
}

const elements = {
    inputDate : document.getElementById('venueDate'),
    btnListVenues : document.getElementById('getVenues'),
    venueInfo : document.getElementById('venue-info')
}

elements.btnListVenues.addEventListener('click', listVenues);

// GET VENUES IDs.
function listVenues(){
    const date = elements.inputDate.value;
    document.getElementById('venueDate').value = '';

    const loadUrl = urls.base + urls.calendar + date;

    fetch(loadUrl, {
        method : 'POST',
        headers : headers
    })
    .then(requestErrorHandler)
    .then(response => response.json())
    .then(data => {
        elements.venueInfo.innerHTML = '';
        for (const id of data) {
            getVenue(id);
        }
    })
    .catch(error => {
        alert(error.message)
    });
}

function getVenue(id){
    const venueUrl = urls.base + urls.venues + id;

    fetch(venueUrl, {
        method : 'GET',
        headers : headers
    })
    .then(requestErrorHandler)
    .then(response => response.json())
    .then(data => {
        const venue = {
            _id : data._id,
            name : data.name,
            description : data.description,
            price : data.price,
            startingHour : data.startingHour
        }

        appendVenueToDom(venue);
    });
}

function appendVenueToDom(venue){
    let div = document.createElement('div');
    div.setAttribute('class', 'venue');
    div.setAttribute('id', venue._id);
    div.innerHTML =
        `<span class='venue-name'><input class='info' type='button' value='More info'>${venue.name}</span>
        <div class='venue-details' style='display: none;'>
            <table>
                <tr>
                    <th>Ticket Price</th>
                    <th>Quantity</th>
                    <th></th>
                </tr>
                <tr>
                    <td class='venue-price'>${venue.price} lv</td>
                    <td><select class='quantity'>
                            <option value='1'>1</option>
                            <option value='2'>2</option>
                            <option value='3'>3</option>
                            <option value='4'>4</option>
                            <option value='5'>5</option>
                        </select></td>
                    <td><input class='purchase' type='button' value='Purchase'></td>
                </tr>
            </table>
            <span class='head'>Venue description:</span>
            <p class='description'>${venue.description}</p>
            <p class='description'>Starting time: ${venue.startingHour}</p>
        </div>`

        let clicks = 0;
        const btnMoreInfo = div.getElementsByClassName('venue-name')[0];
        const btnPurchase = div.getElementsByClassName('purchase')[0];
        btnPurchase.addEventListener('click', (ev)=>purchaseTickets(ev,venue._id,venue.name,venue.price));
        btnMoreInfo.addEventListener('click', loadMoreInfo);
        elements.venueInfo.appendChild(div);
    }
    
    function loadMoreInfo(ev, clicks) {
        const moreInfoMenu = ev.target.parentNode.parentNode.children[1];
        if(moreInfoMenu.style.display === 'block'){
            moreInfoMenu.style.display = 'none';
        } else{
            moreInfoMenu.style.display = 'block';
        }
    }
    
    function purchaseTickets(ev,id,name) {
        const ticketsInfoTable = ev.target.parentNode.parentNode;
        const quantity = ticketsInfoTable.getElementsByClassName('quantity')[0].value;
        let ticketPrice = ticketsInfoTable.getElementsByClassName('venue-price')[0].textContent;
        ticketPrice = parseInt(ticketPrice.substring(0, ticketPrice.length - 3));
    
        elements.venueInfo.innerHTML = `<span class='head'>Confirm purchase</span>
                                          <div class='purchase-info'>
                                            <span>${name}</span>
                                            <span>${quantity} x ${ticketPrice}</span>
                                            <span>Total: ${quantity * ticketPrice} lv</span>
                                            <input type='button' value='Confirm'>
                                          </div>`;
        const btnConfirm = elements.venueInfo.getElementsByTagName('input')[0];
        btnConfirm.addEventListener('click', function () {
            confirmPurchase(id, quantity)
        });
    }
    
    function confirmPurchase(id, qty) {
        fetch(`https://baas.kinvey.com/rpc/kid_BJ_Ke8hZg/custom/purchase?venue=${id}&qty=${qty}`, {
            method: 'POST',
            headers: headers
        })
            .then(response => response.json())
            .then(data => {
                elements.venueInfo.innerHTML = 'You may print this page as your ticket.' + data.html;
            })
    }

function requestErrorHandler(response){
    if(response.status >= 400){
        throw new Error(`Something went wrong! Error : ${response.statusText}`);
    }

    return response;
}
