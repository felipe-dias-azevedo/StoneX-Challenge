# StoneX-Challenge

## Run

You can either run with Docker Compose or with Docker independent containers:

### Docker compose

```bash
docker-compose up
```

Open [http://localhost](http://localhost).


### Docker 

##### Frontend

```bash
docker build -t stonex-frontend ./frontend
docker run --name stonex-frontend -d -p 80:3000 stonex-frontend
```

##### Backend

```bash
docker build -t stonex-backend ./backend
docker run --name stonex-backend -d -p 5130:8080 -e DefaultConnections__ConnectionString=mongodb://localhost:27017/stonex?authSource=admin stonex-backend
```

##### MongoDB

```bash
docker run -d -p 27017:27017 --name stonex-mongo mongo
```

Open [http://localhost](http://localhost).