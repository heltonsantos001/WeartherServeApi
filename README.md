# WeatherServerApi

**WeatherServerApi** é uma API que fornece dados meteorológicos em tempo real e informações sobre a qualidade do ar de qualquer cidade do mundo. Este projeto foi desenvolvido para facilitar o acesso a informações de clima e poluição, tornando esses dados mais acessíveis para desenvolvedores e usuários sem a necessidade de conhecer coordenadas geográficas complexas.

## Funcionalidades

- **Dados Meteorológicos**: Retorna informações em tempo real sobre:
  - Temperatura
  - Umidade
  - Pressão atmosférica
  - Outros elementos climáticos relevantes

- **Dados de Qualidade do Ar**: Retorna a concentração de componentes poluentes, incluindo:
  - Monóxido de Carbono (CO)
  - Óxido Nítrico (NO)
  - Dióxido de Nitrogênio (NO₂)
  - Ozônio (O₃)
  - Dióxido de Enxofre (SO₂)
  - Partículas Finas (PM2.5 e PM10)
  - Amônia (NH₃)

## Como Funciona

A **WeatherServerApi** utiliza as coordenadas geográficas (latitude e longitude) para obter dados exatos de qualquer cidade do mundo. Com base nessas coordenadas:
- A latitude identifica a posição ao norte ou ao sul da linha do Equador.
- A longitude identifica a posição a leste ou a oeste do meridiano de Greenwich.

No entanto, para simplificar o uso, a API permite que você forneça apenas o nome da cidade. O sistema então converte automaticamente para as coordenadas e retorna os dados meteorológicos e de qualidade do ar, eliminando a necessidade de o usuário conhecer esses detalhes geográficos.

## Exemplo de Uso

Faça uma chamada para a API usando o nome da cidade:


Exemplo de resposta qualidade do ar:
```json
{
  "coord": [50, 50],
  "weather": {
    "temperature": 22.5,
    "humidity": 60,
    "pressure": 1012
  },
  "air_quality": {
    "aqi": 1,
    "components": {
      "co": 201.94,
      "no": 0.018,
      "no2": 0.77,
      "o3": 68.66,
      "so2": 0.64,
      "pm2_5": 0.5,
      "pm10": 0.54,
      "nh3": 0.12
    }
  }
}
```

Exemplo de resposta para dados meteorológicos:
```json
{
  "coord": {
    "lon": 7.367,
    "lat": 45.133
  },
  "weather": [
    {
      "id": 501,
      "main": "Rain",
      "description": "moderate rain",
      "icon": "10d"
    }
  ],
  "base": "stations",
  "main": {
    "temp": 284.2,
    "feels_like": 282.93,
    "temp_min": 283.06,
    "temp_max": 286.82,
    "pressure": 1021,
    "humidity": 60,
    "sea_level": 1021,
    "grnd_level": 910
  },
  "visibility": 10000,
  "wind": {
    "speed": 4.09,
    "deg": 121,
    "gust": 3.47
  },
  "rain": {
    "1h": 2.73
  },
  "clouds": {
    "all": 83
  },
  "dt": 1726660758,
  "sys": {
    "type": 1,
    "id": 6736,
    "country": "IT",
    "sunrise": 1726636384,
    "sunset": 1726680975
  },
  "timezone": 7200,
  "id": 3165523,
  "name": "Province of Turin",
  "cod": 200
}

```
Exemplo de resposta para dados de localização:

```json
{
  "city_name": "Province of Turin",
  "latitude": 45.133,
  "longitude": 7.367,
  "country_code": "IT"
} 

```
