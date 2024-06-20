FROM arm64v8/postgres

COPY Modular.App.Database/Scripts/ /docker-entrypoint-initdb.d/

ENV POSTGRES_USER=paul
ENV POSTGRES_PASSWORD=Hash1234/
ENV POSTGRES_DB=app

COPY entrypoint.sh /usr/local/bin/entrypoint.sh
