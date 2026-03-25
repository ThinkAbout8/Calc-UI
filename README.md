# Calc-UI
A simple calculator application built using C# and WPF. This project demonstrates event-driven UI handling, state management, and basic arithmetic operations.

## Getting started

1. Clone the repository
2. Open in Visual Studio
3. Build and Run

## Features
### Basic arithmetic:
- Addition (+)
- Subtraction (-)
- Multiplication (*)
- Division (/)
- Modulus (%)
- Square root calculation
### Memory functions:
- Store (M)
- Recall (MR)
- Clear (MC)
### Input editing:
- Backspace
- Clear
- Sign toggle (+/-)
- Decimal support
### Error handling:
- Division by zero
- Complex square root
- Result overflow

---

## How It Works

The calculator is implemented using a **single event handler** (`Event_Click`) that processes all button inputs.

### Internal State Variables

| Variable | Type   | Description |
|----------|--------|------------|
| `arg1`   | double | First operand |
| `arg2`   | double | Second operand |
| `op`     | char   | Current operator |
| `flt`    | bool   | Indicates decimal mode |
| `sign`   | bool   | Indicates negative value |
| `error`  | bool   | Error state flag |
| `memory` | bool   | Whether memory is active |
| `memc`   | double | Stored memory value |
| `maxdigits` | int | Maximum allowed digits |

---

## Controls

### Number Input
- Buttons `b0`–`b9` append digits to the display
- Limited by `maxdigits`

### Editing
- `bClr` - Reset calculator
- `bBck` - Remove last digit
- `bDot` - Add decimal point
- `bSgn` - Toggle sign

### Operations
- `bAdd` - Addition
- `bSub` - Subtraction
- `bMul` - Multiplication
- `bDiv` - Division
- `bMod` - Modulus
- `bSqr` - Square root

### Execution
- `bEqu` → Executes the selected operation

### Memory
- `bMWr` - Store value
- `bMRd` - Recall value
- `bMCl` -  Clear memory

---

## Error Handling

The app enters an error state (`error = true`) in the following cases:

- Division by zero  
  → `E: Division by 0`

- Square root of negative number  
  → `E: Complex root`

- Result exceeds digit limit  
  → `E: Result too long`

When in error state:
- Most inputs are ignored
- User must press **Clear** to reset

---
