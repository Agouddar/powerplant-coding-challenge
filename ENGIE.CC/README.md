# powerplant-coding-challenge
## author : Khalid AGOUDDAR


The project REST API allows you to generate production plans for energy. By making a POST request to the /productionplan route, you can receive a production plan based on the input data provided. 

## Base URL : http://localhost:8888

## Authentication
No authentication is currently required to access this API.


## Endpoints
Generate Production Plan
Endpoint: POST /productionplan

## Request
Send a POST request to this endpoint to generate a production plan based on the input payload. The input payload should be a JSON object with the required parameters for production plan :
{
  "load": /* desired LOAD*/,
  "fuels": {
    "gas(euro/MWh)": /* Gas price */,
    "kerosene(euro/MWh)": /* Kerosene price */,
    "co2(euro/ton)": /* CO2 price */
    "wind(%): /* wind */
  },
  "powerplants": [
    {
      "name": /* Power plant name */,
      "type": /* Power plant type */,
      "efficiency": /* Efficiency */,
      "pmin": /* Minimum power */,
      "pmax": /* Maximum power */,
    },
    /* Additional power plant objects */
  ]
}

## Response 

[
    {
      "name": "/* Power plant name*/",
      "p": 150,/* production MwH */
    },
    /* Production entries for other power plants */
  ]
}
