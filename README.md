# eRejestracjaCovid19
Prosty program do szukania wolnych slotów na szczepienie Covid 19

1. Zaloguj się na stronie https://pacjent.erejestracja.ezdrowie.gov.pl/ i znajdz request "https://pacjent.erejestracja.ezdrowie.gov.pl/api/patient/{guid}"
2. Skopiuj do settings.json: </br>
  -patient_sid </br>
  -x-csrf-token
3. Skopiuj do find.json i confirm.json </br>
  -prescriptionId
  
![Screenshot](screenshot.png)
  
4. Ustaw w settings.josn miasto oraz odpowiednie dla niego voiId w find.json
5. Zbuduj i uruchom program
