# 🔐 Multiplicative Inverse & Affine Cipher Toolkit

A simple **C# Console Application** that demonstrates:

- Modular Multiplicative Inverse
- Affine Cipher Encryption & Decryption
- Key validation using GCD
- Extended Euclidean Algorithm

---

## 📌 Features

✅ Find modular inverse  
✅ Encrypt text using Affine Cipher  
✅ Decrypt text using Affine Cipher  
✅ Full encryption + decryption round test  
✅ Check if inverse exists  

---

## Concepts Covered

### 1. Modular Inverse
Finding a⁻¹ mod m such that:

a × a⁻¹ ≡ 1 (mod m)

 Exists only when:
gcd(a, m) = 1

---

### 2. Affine Cipher

#### Encryption:
E(x) = (a * x + b) mod m

#### Decryption:
D(y) = a⁻¹ * (y - b) mod m

Where:
- a → multiplicative key
- b → additive key
- m → modulus (26 for English letters)

---

## 📂 Project Structure

Multiplicative_Inverse/
│
├── Program.cs          → UI & Menu  
├── CipherHelper.cs     → Core Logic  

---

## 🛠️ How It Works

### Extended Euclidean Algorithm
Used to compute:

a*x + m*y = gcd(a, m)

From this, we extract the modular inverse.

---

### Encryption Flow
1. Convert each letter → number (A = 0 → Z = 25)
2. Apply formula:
   (a * x + b) % m
3. Convert back to character

---

### Decryption Flow
1. Compute inverse of a
2. Apply:
   a⁻¹ * (y - b) mod m

---

## ▶️ How to Run

1. Open project in Visual Studio  
2. Run the application  
3. Choose from menu:

1 → Find Inverse  
2 → Encrypt  
3 → Decrypt  
4 → Full Test  
5 → Check Validity  
0 → Exit  

---

## Example

### Input:
a = 5  
b = 8  
m = 26  
Text = HELLO  

### Output:
Encrypted: RCLLA  
Decrypted: HELLO  

---

## ⚠️ Important Notes

- a MUST be coprime with m  
- If gcd(a, m) ≠ 1 → ❌ No inverse  
- Only English letters are transformed  
- Other characters remain unchanged  

---

## 🧪 Validation Example

a = 6, m = 26  
gcd(6,26) = 2 → ❌ Invalid  

a = 5, m = 26  
gcd(5,26) = 1 → ✅ Valid  

---

## Possible Improvements

- Support lowercase separately  
- Add GUI (Windows Forms / WPF)  
- Support Arabic alphabet  
- Add brute-force attack demo  
- Save results to file  

---

## 👨‍💻 Author

**Abdallah Ebrahim**
