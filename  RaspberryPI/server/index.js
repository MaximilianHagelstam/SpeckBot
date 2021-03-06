const app = require('express')();
const path = require('path');
const { exec } = require('child_process');

const PORT = 3000;

app.get('/', (req, res) => {
    res.send('Hello Team!');
});

app.post('/on', (req, res) => {
    exec('sudo python ../gpio/on.py');
    res.sendStatus(200);
});

app.post('/off', (req, res) => {
    exec('sudo python ../gpio/off.py');
    res.sendStatus(200);
});

app.listen(PORT, () => {
    console.log(`Server running on port ${PORT}`);
});
