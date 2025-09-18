@Login
Feature: User Login
  As a registered user
  I want to log in to the system
  So that I can access the system's features

  Scenario: Invalid login attempt
    Given I am on the login page
    When I enter invalid credentials
    Then I should see an error message

  Scenario: Login with valid credentials
    Given I am on the login page
    When I enter valid credentials
    Then I should be redirected to the homepage
