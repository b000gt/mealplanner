import requests
import json
from query_generator import get_recipes

url = "https://api.edamam.com/api/recipes/v2"

querystring = {
    "type": "public",
    "app_id": "e9299322",
    "app_key": "983b5ec9516fe45d069a0b58246ef59c",
    "health": ["vegan", "vegetarian", "tree-nut-free"],
    "random": "true",
    "mealType": ["dinner"],
    "dishType": ["Main course"]
}

response = json.loads(get_recipes().text)

for meal in response["hits"]:
    print(f'{meal["recipe"]["label"]}: \t {meal["recipe"]["url"]}')


# print(json.dumps(response, indent=2, sort_keys=True))
