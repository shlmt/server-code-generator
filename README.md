# Server Generator - יוצר שרתי REST-API אוטומטי

## על הפרויקט

כלי .NET שמקבל את פרטי הפרוייקט ומבנה המודלים, ומייצר קוד שרת בסיסי עם מימוש לכל פעולות הCRUD, כולל משתני סביבה והתקנת התלויות.

### תמיכה נוכחית
1. Node.js + mongoDB
2. .net 8 minimalApi + mySql/ms-sqlServer
---

לתורמים
-------

**Server Generator** הוא פרויקט קוד פתוח, המיועד במיוחד לג'וניוריות המעוניינות להתפתח מקצועית.\
נשמח לכל תרומה שעומדת בדרישות הקוד שלנו:

### תחומי תרומה

-   **שיפורים בבדיקות תקינות (Validation)** של הקלט בקונטרולרים.
-   **הוספת תמיכה בשפות שרת ומסדי נתונים** נוספים.
-   **פיתוח ממשק משתמש (UI)** עבור הכלי.
-   **הוספת auth middleware** אם HasAuth=true.
-   החזרת שגיאות ברורות למפתחים.
-   וכל שיפור ושדרוג שעולה בדעתכם.

### דרישות לקוד (גם קוד הC# וגם הקוד המג'ונרט)

1.  **עובד** - יש לוודא שהקוד תקין, ללא באגים, ושהוא מטפל בכל השגיאות.
2.  **מסודר** - שימוש במבנה תיקיות היררכי, ופונקציות כלליות תחת `utils`.
3.  **נכון** - עקרונות OOP, RESTful APIs.
4.  **נקי** - שמות משתנים ופונקציות ברורים, הזחות, ושמירה על קונבנציות קוד.
5. **מובן** - הודעות commit ברורות, שמירה על מבנה זהה בכל המחלקות.


כיצד לתרום?
-----------

1.  **Fork (העתיקו את הפרוייקט אליכם)**\
    בצעו Fork לפרויקט וצרו Branch חדש עם השיפורים שלכם.

    `git checkout -b feature-name`

2.  **Code (ביצוע שינויים)**\
    הוסיפו את השינויים לקוד ובצעו Commit.

    `git commit -m "message"`

3.  **Pull Request (בקשת מיזוג לקוד הראשי)**\
    שלחו Pull Request עם תיאור ברור של השינויים שביצעתם.

לקריאה נוספת על תרומה לקוד פתוח: [מדריך למתחילות: איך להתחיל לתרום לקוד פתוח](https://maakaf.netlify.app/newbies/he_how-to-start-os-practice/)

* * * * *

רישיון - אין להשתמש למטרות מסחריות, ואין להשתמש במקום ביצוע מטלות שניתנו בלימודים.
