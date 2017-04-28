//Libs
#include <mainwindow.h>
#include <ui_mainwindow.h>
#include <QFileDialog>
#include <tools.h>

//Define bools
#define true 1
#define false 0
#define IsLinux false
#define IsWin false
#define IsMac false

//OS specific
#ifdef Q_OS_LINUX
    #define OsName "Linux"
    #define IsLinux true
    #define WoWLoc "/.Wine/."
#elif Q_OS_WIN32
    #define OsName "Windows"
    #define IsWin true
    #define WoWLoc "C:/"
#elif Q_OS_DARWIN
    #define OsName "Mac"
    #define IsMac true
    #define WoWLoc "/"
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
   //QString dirLoc = Tools::OpenExplorer(WoWLoc);
    //ui->wow_loc->setText(QDir::toNativeSeparators(dirLoc));
}

void MainWindow::on_install_bt_clicked() {
    //Tools::MsgBox("Dummy Button");
}

void MainWindow::on_refresh_bt_clicked() {
    //Tools::MsgBox("Dummy Button");
}

void MainWindow::on_wow86_bt_clicked() {
    //Tools::launchApp(WoWLoc, "WoW.exe");
}

void MainWindow::on_wow64_bt_clicked(){
    //Tools::launchApp(WoWLoc, "WoW-64.exe");
}

void MainWindow::on_wow_mac_bt_clicked() {
    //Tools::MsgBox("Dummy Button");
}
