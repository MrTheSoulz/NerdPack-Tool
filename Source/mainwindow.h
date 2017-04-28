#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();

private slots:
    void on_browse_bt_clicked();
    void on_install_bt_clicked();
    void on_refresh_bt_clicked();
    void on_wow86_bt_clicked();
    void on_wow64_bt_clicked();
    void on_wow_mac_bt_clicked();

private:
    Ui::MainWindow *ui;
};

#endif // MAINWINDOW_H
