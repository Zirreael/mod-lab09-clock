# МИПиС
## mod-lab09-clock

![GitHub pull requests](https://img.shields.io/github/issues-pr/UNN-IASR/mod-lab09-clock)
![GitHub closed pull requests](https://img.shields.io/github/issues-pr-closed/UNN-IASR/mod-lab09-clock)


## Lab 09. Разработка аналоговых часов

Срок выполнения работы: **до 1 июня**

![Relative date](https://img.shields.io/date/1653253200)

**Цель работы:** научиться создавать приложения **Windows Forms** с использованием элементов графики, изучить событие **Paint**.

## Часы

В данной работе нужно написать реализацию стрелочных часов. В качестве примера можно привести слудующее изображение 

![](images/clock.png)

Разработайте собственный дизайн стрелок и циферблата.


## Выполнение работы

Работа выполняется в **MS Visual Studio**. Тип приложения - **Windows Forms**.

Объявление пакетов:

```
using System.Drawing;
using System.Drawing.Drawing2D;
```

Главный код программы сосредоточен в функции-обработчике события

```
 private void Form_Paint(object sender, PaintEventArgs e)
```

Алгоритм работы обработчика можно описать следующим образом:

- Получение доступа к текущему времени 

  ```DateTime dt = DateTime.Now;```

- Создание перьев и кистей для рисования

  ```
   Pen cir_pen = new Pen(Color.Black,2);
   Brush brush = new SolidBrush(Color.Indigo); 
  ```
- Получение графического контекста 

  ```
   Graphics g = e.Graphics;
  ```
- Объявление объекта для сохранения текущего состояния

  ```
   GraphicsState gs;
  ```

- Масштабирование рисунка и перенесение начала координат в центр

  ```
  g.TranslateTransform(w / 2, h / 2);
  g.ScaleTransform(w / 200, h / 200);
  ```
- Рисование циферблата

  ```
  g.DrawEllipse(cir_pen, -120, -120, 240, 240);
  ```

- Рисование стрелок

  Стрелки рисуются в виде прямых линий или соединенных несколько точек линиями (Polygon). Положение линий определяется текущим временем, которое нужно перевести в градусы поворота относительно начала координат на окружности (вертикальная линия).

  ```
  gs = g.Save();
  g.RotateTransform(6 * (dt.Minute + (float)dt.Second / 60));
  g.DrawLine(new Pen(new SolidBrush(Color.Brown), 4), 0, 0, 0, -80);
  g.Restore(gs);
  ```
  Сначала сохраняется текущее состояние, потов выполняется поворот на заданное количество градусов и рисуется линия. Потом восстанавливается текущее состояние графического контекста. 
  
  - Для активизации процедуры рисования надо создать элемент управления **Timer** и назначить обработчик события **Tick** (с частотой 1 раз в секунду)
  
  ```
   private void timer1_Tick(object sender, EventArgs e)
   {
       this.Invalidate();
   }
   ```
   вызов **Invalidate()** приводит к необходимости перерисовки формы, для чего вызывается обработчик **Paint**

## Результаты работы

В качестве результатов работа необходимо загрузить решение VS с файлами, имеющими следующие расширения (строго!)

- **.cs**
- **.resx**
- **.settings**
- **.config**
- **.csproj**
- **.sln**
- **.txt**
- **.png**

Исполняемые, бинарные, временные файлы загружать не нужно!

Сделать скриншот главного окна приложения Windows Forms и поместить файл с именем **clock_main.png**в корень репозитория.

**Примечание**. В данной работе не требуется писать тесты.
