# CloudTrack - API Gateway

## Table of contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Setup](#setup)
* [Repositories](#repositories)

## General info
CloudTrack is an example application to support run competitions.
This repository contains an API Gateway project.

## Technologies
Project is created with:
* C#
* .NET 9
* YARP
* Open Telemetry

## Setup
To run this project from GitHub Actions:

* Define GitHub Actions secret named AZURE_CREDENTIALS and put there the value from the previous step

* Define GitHub Actions secret named REGISTRY_LOGIN_SERVER and put there your Azure Container Registry login server

* Define GitHub Actions secret named REGISTRY_USERNAME and put there your Azure Container Registry username

* Define GitHub Actions secret named REGISTRY_PASSWORD and put there your Azure Container Registry password

* Define GitHub Actions variable named AZURE_GROUP and put there correct name of Azure resource group name where do you want to deploy your resources

## Repositories
* Infrastructure: [github.com/beniaminzaborski/cloudtrack-infra](https://github.com/beniaminzaborski/cloudtrack-infra)
* API Gateway: [github.com/beniaminzaborski/cloudtrack-apigw](https://github.com/beniaminzaborski/cloudtrack-apigw)
* Competitions: [github.com/beniaminzaborski/cloudtrack-compet](https://github.com/beniaminzaborski/cloudtrack-compet)
* Registration: [github.com/beniaminzaborski/cloudtrack-regstr](https://github.com/beniaminzaborski/cloudtrack-regstr)
