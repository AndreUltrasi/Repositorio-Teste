const client_2 = require('./client-2.json');
const express = require('express');
const bodyParser = require('body-parser');
const compression = require('compression');
const port = 3010
const app = express();

app.use(compression());
app.use(bodyParser.json());
app.use(express.urlencoded({ extended: true }));

app.get('/api/v1/client/:client', function (req, res) {
	var client = req.params.client;
	console.log(`client: ${client}`);
	if(client == 2){
		return res.status(200).json(client_2);		
	}
	
	return res.status(404).json("Not Found");
});

app.get('/', function (req, res) {
	return res.status(404).json("Not Found");
});


app.listen(port, () => console.log(`app listening on port ${port} !`));