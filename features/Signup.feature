@Signup
Feature: User Registration
  As a user
  I want to register on the system
  So that I can have an account and access the features

  Scenario: Successful user registration
    Given the user is on the signup page
    When the user fills in the valid details
    Then the system should display a success message

  Scenario: Registering with an existing email
    Given the user is on the signup page
    When the user tries to register with an existing email
    Then the system should display the message "Email Address already exist!"
