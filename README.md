# Elasticsearch_webapp
This is an MVC based web app having a search functionality built using Elasticsearch and .NETCore. This project is built on Visual Studio 2019 (MVC .NetCore). Elasticsearch_webapp folder contains the solution file as well as the codebase for the app.

## Requirements
1. <a href = "https://visualstudio.microsoft.com/downloads/">Visual Studio 2019</a> with .NETCore packages. Install Nuget packages Elasticserach.Net and NEST.
2. Elasticsearch - Download and install elasticsearch as service to your system. (See <a href = "https://www.elastic.co/">here</a>)

## How to run?
1. Clone this repository to your system.
2. Start Elasticsearch.
3. Load sample-data.json onto the elastocsearch using the folllowing command. (<a href="https://code-maze.com/elasticsearch-aspnet-core/">Source</a>)

curl -XPOST localhost:9200/books/book/_bulk --data-binary @sample-data.json -H "Content-Type: application/json"

4. Run the dbdsfsdbfbsnsanvsnv and send queries.
