В чому рішення я використав паттерн стратегія.
Для чого мені знадобилось створити інтерфйес ICalculationStrategy який має опис метода Calculate
Потім кожна нова реалізація наслідується від ICalculationStrategy та робить свою реалізацію метода Calculate 
А в головному класі я стоврив словник де ключ це type за яким треба калькулювати, а значення це класс який наслідеється від ICalculationStrategy.
Завдяки чому я маю змогу не змінювати класс SuperCalculator та додавати нові реалізації
