const credentials = {
    appId: "kid_BJXTsSi-e",
    appSecret: "447b8e7046f048039d95610c1b039390",
    username: "guest",
    password: "guest"
};

const baseUrl = `https://baas.kinvey.com/appdata/kid_BJXTsSi-e/knock?query=`;
let base_64 = btoa(`${credentials.username}:${credentials.password}`)

const headers = {
    "Authorization": `Basic ${base_64}`,
    "Content-type": "application/json",
};

let currentMessage = "Knock Knock.";

(async function getNextAnswer() {
    let response = await fetch(`${baseUrl}${currentMessage}`, {
        headers: headers
    })
    .then(response => response.json());

    if (response.message) {
        console.log(`Message: ${currentMessage}`);
        console.log(`Answer: ${response.answer}`);
        currentMessage = response.message;
        getNextAnswer();
    } else {
        console.log(`Message: ${currentMessage}`);
        console.log(`Answer: ${response.answer}`);
    }
})();
