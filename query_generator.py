
import requests

url = "https://api.edamam.com/api/recipes/v2"

app_id = "e9299322"
app_key = "983b5ec9516fe45d069a0b58246ef59c"

def get_recipes():
    querystring = {
        "type": "public",
        "app_id": app_id,
        "app_key": app_key,
        "health": ["vegan", "vegetarian", "tree-nut-free"],
        "random": "true",
        "mealType": ["dinner"],
        "dishType": ["Main course"]
    }
    return requests.request("GET", url, params=querystring)