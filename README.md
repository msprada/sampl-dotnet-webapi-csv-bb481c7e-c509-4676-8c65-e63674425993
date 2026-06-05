# BPol Flight Api

## Docker

### Build Image

```bash
docker build -t bpol-api .
```

## Run Container

```bash
docker run -d  -p 8080:8080 --name pbol_api bpol-api
```

## Get Data Local

```
# Get JSON
curl -H "Accept: application/json" http://localhost:5000/api/flights


# Get CSV
curl -H "Accept: text/csv"  http://localhost:5000/api/flights
```

## SwaggerUI Development

```
export ASPNETCORE_ENVIRONMENT=Development
dotnet run
```

Aufruf via http://localhost:5000/swagger/
