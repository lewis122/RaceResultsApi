const { Given, When, Then } = require('@cucumber/cucumber')
const supertest = require('supertest')
const request = supertest('https://jsonplaceholder.typicode.com')
const assert = require('assert')



Given('I am a user', () => {
    // no-op
})

When('I send a GET request to Get all races', async function () {
    this.response = await request.get('http://localhost:3000/Results')
})

Then('the API should respond with status code 200', async function () { //Same function for two scenarios 1 and 3
    assert.equal(this.response.status, 200)
    assert.equal(this.response.body, JSON.stringify({}))
})