//Libs
#include <mainwindow.h>
#include <ui_mainwindow.h>
#include <QFileDialog>
#include <tools.h>

Tools tools;

//Define bools
#define true 1
#define false 0

//OS specific
#ifdef Q_OS_LINUX
    QString OsName = "Linux";
    bool IsWin = false;
    bool IsLinux = true;
    bool IsMac = false;
    QString WoWLoc = "/.Wine/C:/Program Files (x86)/World of Warcraft"
#elif _WIN32 || _WIN64
    QString OsName = "Windows";
    bool IsWin = true;
    bool IsLinux = false;
    bool IsMac = false;
    QString WoWLoc = "C:\\Program Files (x86)\\World of Warcraft";
#elif Q_OS_DARWIN
    QString OsName = "MacOS";
    bool IsWin = false;
    bool IsLinux = false;
    bool IsMac = true;
    QString WoWLoc = "/Applications"
#endif

MainWindow::MainWindow(QWidget *parent) : QMainWindow(parent), ui(new Ui::MainWindow) {
    ui->setupUi(this);

    //Set Toolbox info
    ui->ver_strg->setText("VERSION??");
    ui->os_strg->setText(OsName);
    ui->wow_loc->setText(WoWLoc);

    //Launch Buttons
    if (IsLinux||IsWin) {
        ui->wow64_bt->setEnabled(true);
        ui->wow86_bt->setEnabled(true);
    } else if (IsMac) {
        ui->wow_mac_bt->setEnabled(true);
    }

    //Set BackGround
    QPixmap nep_bg(":/MyFiles/Resources/logo.png");
    ui->bg_grp->setPixmap(nep_bg);
    ui->bg_grp->setText("");
    ui->bg_grp->resize(this->size());
    update();
}

MainWindow::~MainWindow() {
    delete ui;
}

void MainWindow::on_browse_bt_clicked() {
   QString dirLoc = tools.OpenExplorer(WoWLoc);
    ui->wow_loc->setText(dirLoc);
    WoWLoc = dirLoc;
}

void MainWindow::on_install_bt_clicked() {
    tools.MsgBox("Dummy Button");
}

void MainWindow::on_refresh_bt_clicked() {
    tools.MsgBox("Dummy Button");
}

void MainWindow::on_wow86_bt_clicked() {
    tools.launchApp(WoWLoc, "Wow.exe");
}

void MainWindow::on_wow64_bt_clicked(){
    tools.launchApp(WoWLoc, "Wow-64.exe");
}

void MainWindow::on_wow_mac_bt_clicked() {
    tools.launchApp(WoWLoc, "World of Warcraft.app");
}
