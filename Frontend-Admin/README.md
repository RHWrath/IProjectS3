# SolidJS example

This is an example frontend with [SolidJS](https://docs.solidjs.com) and [SolidUI](https://www.solid-ui.com/docs/introduction) that uses the example backend.

## Installing dependencies

We use pnpm for package management. Install it with `npm i -g pnpm`.

Then install the dependencies with `pnpm i`.

Remember to never use normal npm with this project ever again. If you do, your node_modules will be fucked up severely. This isn't a threat, this is a fact. To save yourself you can `alias npm="echo 'no npm, only pnpm'"` and `alias npx="echo 'no npx, only pnpm npx'"` in your shell config.

## Running the app

Run `pnpm start` to start the app in development mode.

## Installing Components

Run `pnpm npx solidui-cli@0.6.8 add dialog`

## running program

before running said the program through bash start.sh always run export ASPNETCORE_ENVIRONMENT=Development
and if you wish to change to main run ASPNETCORE_ENVIRONMENT=Production

## Eslint
run `pnpm npx eslint` in frontend folders for CQA

## Cypress
run `pnpm npx cypress open` in cypress for E2E
