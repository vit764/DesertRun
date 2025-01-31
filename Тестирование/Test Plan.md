# План тестирования
 ### Содержание
  1. [Введение](#1)
  2. [Объект тестирования](#2)
  3. [Риски](#4)
  4. [Аспекты тестирования](#5)<br>
  5. [Подходы к тестированию](#6)
  6. [Представление результатов](#7)
  7. [Выводы](#8)
  <a name="1"></a>
 ## 1. Введение
Содержание данного документа описывает план тестирования desktop-приложения "Desert Run". Цель проведения тестирования - проверка приложения в соответствии с SRS.
<a name="2"></a>
 ## 2. Объект тестирования
### 1. Функциональная пригодность
-   #### Функциональная полнота
    Набор функций приложения должен покрывать все возможности, описанные в SRS.
-   #### Функциональная корректность
    Приложение должно выполнять все заявленные функции корректно.
-   #### Функциональная целесообразность.
    Отсутствуют не заявленные функции, которые бы мешали приложению выполнять первоначально поставленные задачи.
### 2. Удобство использования
-   #### Доступность пользовательского интерфейса
    Элементы управления объектами должны быть всегда доступны пользователю
-   #### Актуальность
    Все изменения происходят в режиме реального времени
<a name="3"></a>
## 3. Риски
К рискам можно отнести:
- Скорость обработки игровой логики зависит от процессора девайса
<a name="4"></a>
 ## 4. Аспекты тестирования
В ходе тестирования должна быть проверена реализация основных функций приложения, к которым относятся:  
1. Начать игру
2. Приобрести скин 
3. Изменить громкость музыки
4. Проиграть в игру
5. Поставить на паузу
6. Продолжить игру после паузы
7. Выход в меню после окончания игры
8. Сыграть еще раз после окончания игры
9. Закрыть приложение
10. Понятный геймплей
11. Производительность

### Функциональные требования:
#### 1. Начать игру
Этот вариант использования небходимо протестировать при активированых разных скинах.

#### 2. Приобрести скин 
Этот вариант использования небходимо протестировать на возможность покупки одного из скинов.

#### 3. Изменить громкость музыки
Этот вариант использования небходимо протестировать на возможность изменения громкости фоновой музыки.

#### 4. Проиграть в игру
Этот вариант использования небходимо протестировать при столкновении Персонажа с препятствием. В данном случае пользователю должно отобразиться сообщение о проигрыше.

#### 5. Поставить на паузу
Этот вариант использования небходимо протестировать во время игрового процесса. При нажатии клавиши "Esc" пользователю должно отобразиться меню паузы, а игра должна быть приостановлена.

#### 6. Продолжить игру после паузы
Этот вариант использования небходимо протестировать на корректное продолжение игры после отжатия паузы.

#### 7. Выход в меню после окончания игры
Этот вариант использования небходимо протестировать на возможность после кончания игры в всплывающем окне нажать на кнопку "Menu". После чего пользователю отобразится окно главного меню.

#### 8. Сыграть еще раз после окончания игры
Этот вариант использования небходимо протестировать на возможность после кончания игры в всплывающем окне нажать на кнопку "Restart". После чего пользователю отобразится окно c игровым полем.

#### 9. Закрыть приложение
Этот вариант использования небходимо протестировать при нажатии на кнопку в главном меню "Exit". В данном случае работа приложения должна завершиться.

### Нефункциональные требования:
#### 1. Понятный геймплей
Понимание того, что надо делать после одной-трех игр.

#### 2. Производительность
Отсутствие фризов во время использования приложения

<a name="5"></a>
## 5. Подходы к тестированию
Для тестирования приложения необходимо вручную проверить каждый аспект тестирования.

<a name="6"></a>
## 6. Представление результатов
Результаты тестирования представлены в [документе](https://github.com/vit764/DesertRun/blob/master/%D0%A2%D0%B5%D1%81%D1%82%D0%B8%D1%80%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D0%B5/Test%20Result.md).

<a name="7"></a>
## 7. Вывод
Данный тестовый план позволяет протестировать основной функционал приложения. Успешное прохождение всех тестов с высокой вероятностью можно говорить о хорошей работоспособности, и о том, что данное программное обеспечение работает корректно.
