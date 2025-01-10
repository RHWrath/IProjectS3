describe('visit admin page and login', () => {
  it('when login is succesful', () => {
    cy.visit('https://admin.localhost/')
    cy.get(".UsernameInput").type("Admin")
    cy.get(".UsernameInput").should("have.value", "Admin")
    cy.get(".PasswordInput").type("TL1")
    cy.get(".PasswordInput").should("have.value", "TL1")
    cy.get(".LoginSubmit").click()
    cy.get(".LoginToaster").first().contains("Succes:")
  })
  it('when it gets an error', () =>{
    cy.visit('https://admin.localhost/')
    cy.get(".UsernameInput").type("Admin")
    cy.get(".UsernameInput").should("have.value", "Admin")
    cy.get(".PasswordInput").type("Error")
    cy.get(".PasswordInput").should("have.value", "Error")
    cy.get(".LoginSubmit").click()
    cy.get(".LoginToaster").first().contains("ERROR:")
  })

})