# C# Bank Challenge

## Learning Objectives
- Create domain models from user stories
- Create class diagrams from domain models
- Use a red, green, refactor approach to develop robust software
- Use object-oriented principles to organise a codebase

## Set up instructions
- Fork this repository and clone the forked version to your machine
- Open the Boolean.sln

It's time to flex your programming skills. There are no classes or tests included in this repository to get you started, but you will find the usual `../java/com/booleanuk/core` directories to place your classes and tests in.

Your task is to use everything you've learned to build a small banking application.

## Requirements

1. You **must** create domain models from the user stories provided and include them in the repository
2. You **must** create class diagrams from your domain models
3. You **must** use a test-driven development approach to complete this challenge, demonstrate this by committing your work after writing a test and after writing source code to pass it
4. You **must** demonstrate object-oriented principles. You need not include every concept, but you should strive to include as many as possible
5. You can decide whether to use composition, inheritance, or a combination of both, but at least one **must** be present

## User Stories

```
As a customer,
So I can safely store use my money,
I want to create a current account.

As a customer,
So I can save for a rainy day,
I want to create a savings account.

As a customer,
So I can keep a record of my finances,
I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.

As a customer,
So I can use my account,
I want to deposit and withdraw funds.
```

## Acceptance Criteria

**Given** a client makes a deposit of 1000 on 10-01-2012  
**And** a deposit of 2000 on 13-01-2012  
**And** a withdrawal of 500 on 14-01-2012  
**When** she prints her bank statement  
**Then** she would see:

```
date       || credit  || debit  || balance
14/01/2012 ||         || 500.00 || 2500.00
13/01/2012 || 2000.00 ||        || 3000.00
10/01/2012 || 1000.00 ||        || 1000.00
```

## Extensions

```
As an engineer,
So I don't need to keep track of state,
I want account balances to be calculated based on transaction history instead of stored in memory.

As a bank manager,
So I can expand,
I want accounts to be associated with specific branches.

As a customer,
So I have an emergency fund,
I want to be able to request an overdraft on my account.

As a bank manager,
So I can safeguard our funds,
I want to approve or reject overdraft requests.

As a customer,
So I can stay up to date,
I want statements to be sent as messages to my phone.
```

