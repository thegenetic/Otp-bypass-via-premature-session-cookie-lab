# OTP Bypass via Premature Session Cookie

[![YouTube](https://img.shields.io/badge/YouTube-Watch-red)]([your-youtube-link](https://youtu.be/Rreozx8Ccow))
[![Medium](https://img.shields.io/badge/Medium-Read-black)](your-medium-link)

A deliberately vulnerable **ASP.NET Core 8** application demonstrating a critical MFA bypass: the application issues a full authentication cookie **before** OTP verification, allowing attackers to reuse that cookie and access protected endpoints without the second factor.

This lab accompanies a full walkthrough video and blog post. Perfect for pentesters, developers, and security enthusiasts learning about authentication flaws.

---

## 📦 Quick Start with Docker

```bash
docker build -t otp-bypass-lab .
docker run -d -p 5000:80 --name labotp otp-bypass-lab
```

Then open http://localhost:5000/Account/Login

**Credentials:**  
Username: `thegenetic`  
Password: `password123`  
OTP: `123456`

---

## 📚 Resources

- [🎥 YouTube Video – Full Walkthrough]([your-youtube-link](https://youtu.be/Rreozx8Ccow))
- [✍️ Medium Article – Deep Dive & Fix](your-medium-link)
- [OWASP Session Management Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [OWASP MFA Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Multifactor_Authentication_Cheat_Sheet.html)

---

## 📄 License

MIT – free to use for education and testing.
