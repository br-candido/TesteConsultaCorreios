Feature: ConsultaCorreios
 
@ConsultaCorreios
Scenario: Check for a wrong CEP
    Given that I am on the Correios website
    Then find the text box to enter the CEP "80700000"
    Then enter the result tab
    Then check if the CEP doesn't exist
    Then close the browser instance

Scenario: Check for a existing CEP
    Given that I am on the Correios website
    Then find the text box to enter the CEP "01013-001"
    Then enter the result tab
    Then check if the CEP matches the location "Rua Quinze de Novembro, São Paulo/SP"
    Then close the browser instance

Scenario: Check for a non-existing package ID
    Given that I am on the Correios website
    Then switch to the package search tab
    Then find the text box to enter the Package ID "SS987654321BR"
    Then wait for the user to solve the captcha
    Then validate if the package is non-existent
    Then close the browser instance
