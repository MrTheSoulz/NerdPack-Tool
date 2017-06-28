/********************************************************************************
** Form generated from reading UI file 'mainwindow.ui'
**
** Created by: Qt User Interface Compiler version 5.9.0
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_MAINWINDOW_H
#define UI_MAINWINDOW_H

#include <QtCore/QVariant>
#include <QtWidgets/QAction>
#include <QtWidgets/QApplication>
#include <QtWidgets/QButtonGroup>
#include <QtWidgets/QCheckBox>
#include <QtWidgets/QComboBox>
#include <QtWidgets/QGroupBox>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QLabel>
#include <QtWidgets/QLineEdit>
#include <QtWidgets/QMainWindow>
#include <QtWidgets/QProgressBar>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QTabWidget>
#include <QtWidgets/QTableWidget>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_MainWindow
{
public:
    QWidget *centralWidget;
    QTabWidget *tabWidget;
    QWidget *core_tab;
    QLabel *bg_grp;
    QGroupBox *core_grpbox;
    QLabel *label;
    QComboBox *comboBox;
    QCheckBox *checkBox;
    QGroupBox *groupBox;
    QLabel *label_2;
    QLabel *label_3;
    QLabel *label_4;
    QLineEdit *forks_strg;
    QLineEdit *starts_strg;
    QLineEdit *lastupdated_strg;
    QGroupBox *groupBox_2;
    QPushButton *wow86_bt;
    QPushButton *wow64_bt;
    QPushButton *wow_mac_bt;
    QGroupBox *groupBox_3;
    QLineEdit *wow_loc;
    QPushButton *browse_bt;
    QGroupBox *toolbox_grp;
    QLabel *label_5;
    QLabel *label_6;
    QLineEdit *ver_strg;
    QLineEdit *os_strg;
    QWidget *cr_tab;
    QTableWidget *cr_tb;
    QWidget *modules_tab;
    QTableWidget *mod_tb;
    QWidget *stg_tab;
    QWidget *log_tab;
    QProgressBar *progressBar;
    QPushButton *refresh_bt;
    QPushButton *install_bt;

    void setupUi(QMainWindow *MainWindow)
    {
        if (MainWindow->objectName().isEmpty())
            MainWindow->setObjectName(QStringLiteral("MainWindow"));
        MainWindow->resize(760, 400);
        MainWindow->setMinimumSize(QSize(760, 400));
        MainWindow->setMaximumSize(QSize(760, 400));
        QIcon icon;
        icon.addFile(QStringLiteral(":/MyFiles/Resources/icon.ico"), QSize(), QIcon::Normal, QIcon::Off);
        MainWindow->setWindowIcon(icon);
        centralWidget = new QWidget(MainWindow);
        centralWidget->setObjectName(QStringLiteral("centralWidget"));
        tabWidget = new QTabWidget(centralWidget);
        tabWidget->setObjectName(QStringLiteral("tabWidget"));
        tabWidget->setGeometry(QRect(0, 0, 761, 375));
        core_tab = new QWidget();
        core_tab->setObjectName(QStringLiteral("core_tab"));
        core_tab->setAutoFillBackground(false);
        bg_grp = new QLabel(core_tab);
        bg_grp->setObjectName(QStringLiteral("bg_grp"));
        bg_grp->setEnabled(true);
        bg_grp->setGeometry(QRect(0, 0, 101, 21));
        bg_grp->setMinimumSize(QSize(91, 0));
        core_grpbox = new QGroupBox(core_tab);
        core_grpbox->setObjectName(QStringLiteral("core_grpbox"));
        core_grpbox->setGeometry(QRect(10, 10, 201, 211));
        core_grpbox->setAutoFillBackground(true);
        label = new QLabel(core_grpbox);
        label->setObjectName(QStringLiteral("label"));
        label->setGeometry(QRect(6, 30, 91, 20));
        comboBox = new QComboBox(core_grpbox);
        comboBox->setObjectName(QStringLiteral("comboBox"));
        comboBox->setEnabled(false);
        comboBox->setGeometry(QRect(70, 30, 111, 22));
        checkBox = new QCheckBox(core_grpbox);
        checkBox->setObjectName(QStringLiteral("checkBox"));
        checkBox->setGeometry(QRect(10, 60, 181, 16));
        checkBox->setChecked(true);
        groupBox = new QGroupBox(core_grpbox);
        groupBox->setObjectName(QStringLiteral("groupBox"));
        groupBox->setGeometry(QRect(10, 90, 181, 111));
        groupBox->setAutoFillBackground(true);
        label_2 = new QLabel(groupBox);
        label_2->setObjectName(QStringLiteral("label_2"));
        label_2->setGeometry(QRect(10, 30, 51, 16));
        label_3 = new QLabel(groupBox);
        label_3->setObjectName(QStringLiteral("label_3"));
        label_3->setGeometry(QRect(10, 50, 47, 16));
        label_4 = new QLabel(groupBox);
        label_4->setObjectName(QStringLiteral("label_4"));
        label_4->setGeometry(QRect(10, 70, 91, 16));
        forks_strg = new QLineEdit(groupBox);
        forks_strg->setObjectName(QStringLiteral("forks_strg"));
        forks_strg->setGeometry(QRect(70, 30, 101, 16));
        starts_strg = new QLineEdit(groupBox);
        starts_strg->setObjectName(QStringLiteral("starts_strg"));
        starts_strg->setGeometry(QRect(70, 50, 101, 16));
        lastupdated_strg = new QLineEdit(groupBox);
        lastupdated_strg->setObjectName(QStringLiteral("lastupdated_strg"));
        lastupdated_strg->setGeometry(QRect(10, 90, 161, 16));
        groupBox_2 = new QGroupBox(core_tab);
        groupBox_2->setObjectName(QStringLiteral("groupBox_2"));
        groupBox_2->setGeometry(QRect(550, 0, 201, 121));
        groupBox_2->setAutoFillBackground(true);
        wow86_bt = new QPushButton(groupBox_2);
        wow86_bt->setObjectName(QStringLiteral("wow86_bt"));
        wow86_bt->setEnabled(false);
        wow86_bt->setGeometry(QRect(10, 30, 181, 23));
        wow64_bt = new QPushButton(groupBox_2);
        wow64_bt->setObjectName(QStringLiteral("wow64_bt"));
        wow64_bt->setEnabled(false);
        wow64_bt->setGeometry(QRect(10, 60, 181, 23));
        wow_mac_bt = new QPushButton(groupBox_2);
        wow_mac_bt->setObjectName(QStringLiteral("wow_mac_bt"));
        wow_mac_bt->setEnabled(false);
        wow_mac_bt->setGeometry(QRect(10, 90, 181, 23));
        groupBox_3 = new QGroupBox(core_tab);
        groupBox_3->setObjectName(QStringLiteral("groupBox_3"));
        groupBox_3->setGeometry(QRect(0, 300, 751, 51));
        wow_loc = new QLineEdit(groupBox_3);
        wow_loc->setObjectName(QStringLiteral("wow_loc"));
        wow_loc->setGeometry(QRect(10, 20, 651, 20));
        browse_bt = new QPushButton(groupBox_3);
        browse_bt->setObjectName(QStringLiteral("browse_bt"));
        browse_bt->setGeometry(QRect(660, 20, 89, 20));
        toolbox_grp = new QGroupBox(core_tab);
        toolbox_grp->setObjectName(QStringLiteral("toolbox_grp"));
        toolbox_grp->setGeometry(QRect(550, 230, 201, 81));
        toolbox_grp->setAutoFillBackground(true);
        label_5 = new QLabel(toolbox_grp);
        label_5->setObjectName(QStringLiteral("label_5"));
        label_5->setGeometry(QRect(10, 30, 67, 16));
        label_6 = new QLabel(toolbox_grp);
        label_6->setObjectName(QStringLiteral("label_6"));
        label_6->setGeometry(QRect(10, 50, 67, 16));
        ver_strg = new QLineEdit(toolbox_grp);
        ver_strg->setObjectName(QStringLiteral("ver_strg"));
        ver_strg->setGeometry(QRect(80, 30, 113, 16));
        os_strg = new QLineEdit(toolbox_grp);
        os_strg->setObjectName(QStringLiteral("os_strg"));
        os_strg->setEnabled(true);
        os_strg->setGeometry(QRect(80, 50, 113, 16));
        os_strg->setAcceptDrops(true);
        tabWidget->addTab(core_tab, QString());
        cr_tab = new QWidget();
        cr_tab->setObjectName(QStringLiteral("cr_tab"));
        cr_tb = new QTableWidget(cr_tab);
        if (cr_tb->columnCount() < 5)
            cr_tb->setColumnCount(5);
        QTableWidgetItem *__qtablewidgetitem = new QTableWidgetItem();
        cr_tb->setHorizontalHeaderItem(0, __qtablewidgetitem);
        QTableWidgetItem *__qtablewidgetitem1 = new QTableWidgetItem();
        cr_tb->setHorizontalHeaderItem(1, __qtablewidgetitem1);
        QTableWidgetItem *__qtablewidgetitem2 = new QTableWidgetItem();
        cr_tb->setHorizontalHeaderItem(2, __qtablewidgetitem2);
        QTableWidgetItem *__qtablewidgetitem3 = new QTableWidgetItem();
        cr_tb->setHorizontalHeaderItem(3, __qtablewidgetitem3);
        QTableWidgetItem *__qtablewidgetitem4 = new QTableWidgetItem();
        cr_tb->setHorizontalHeaderItem(4, __qtablewidgetitem4);
        cr_tb->setObjectName(QStringLiteral("cr_tb"));
        cr_tb->setGeometry(QRect(0, 0, 761, 341));
        tabWidget->addTab(cr_tab, QString());
        modules_tab = new QWidget();
        modules_tab->setObjectName(QStringLiteral("modules_tab"));
        mod_tb = new QTableWidget(modules_tab);
        if (mod_tb->columnCount() < 5)
            mod_tb->setColumnCount(5);
        QTableWidgetItem *__qtablewidgetitem5 = new QTableWidgetItem();
        mod_tb->setHorizontalHeaderItem(0, __qtablewidgetitem5);
        QTableWidgetItem *__qtablewidgetitem6 = new QTableWidgetItem();
        mod_tb->setHorizontalHeaderItem(1, __qtablewidgetitem6);
        QTableWidgetItem *__qtablewidgetitem7 = new QTableWidgetItem();
        mod_tb->setHorizontalHeaderItem(2, __qtablewidgetitem7);
        QTableWidgetItem *__qtablewidgetitem8 = new QTableWidgetItem();
        mod_tb->setHorizontalHeaderItem(3, __qtablewidgetitem8);
        QTableWidgetItem *__qtablewidgetitem9 = new QTableWidgetItem();
        mod_tb->setHorizontalHeaderItem(4, __qtablewidgetitem9);
        mod_tb->setObjectName(QStringLiteral("mod_tb"));
        mod_tb->setGeometry(QRect(0, 0, 761, 341));
        tabWidget->addTab(modules_tab, QString());
        stg_tab = new QWidget();
        stg_tab->setObjectName(QStringLiteral("stg_tab"));
        tabWidget->addTab(stg_tab, QString());
        log_tab = new QWidget();
        log_tab->setObjectName(QStringLiteral("log_tab"));
        tabWidget->addTab(log_tab, QString());
        progressBar = new QProgressBar(centralWidget);
        progressBar->setObjectName(QStringLiteral("progressBar"));
        progressBar->setGeometry(QRect(0, 372, 611, 31));
        progressBar->setValue(0);
        progressBar->setAlignment(Qt::AlignCenter);
        progressBar->setTextVisible(true);
        refresh_bt = new QPushButton(centralWidget);
        refresh_bt->setObjectName(QStringLiteral("refresh_bt"));
        refresh_bt->setGeometry(QRect(720, 371, 41, 31));
        QIcon icon1;
        icon1.addFile(QStringLiteral(":/MyFiles/Resources/refresh.png"), QSize(), QIcon::Normal, QIcon::Off);
        refresh_bt->setIcon(icon1);
        refresh_bt->setCheckable(false);
        install_bt = new QPushButton(centralWidget);
        install_bt->setObjectName(QStringLiteral("install_bt"));
        install_bt->setGeometry(QRect(610, 371, 111, 31));
        MainWindow->setCentralWidget(centralWidget);

        retranslateUi(MainWindow);

        tabWidget->setCurrentIndex(0);


        QMetaObject::connectSlotsByName(MainWindow);
    } // setupUi

    void retranslateUi(QMainWindow *MainWindow)
    {
        MainWindow->setWindowTitle(QApplication::translate("MainWindow", "NerdPack ToolBox", Q_NULLPTR));
#ifndef QT_NO_ACCESSIBILITY
        core_tab->setAccessibleName(QString());
#endif // QT_NO_ACCESSIBILITY
        bg_grp->setText(QApplication::translate("MainWindow", "!!!BACKGROUND!!", Q_NULLPTR));
        core_grpbox->setTitle(QApplication::translate("MainWindow", "NerdPack's Core Settings", Q_NULLPTR));
        label->setText(QApplication::translate("MainWindow", "Release:", Q_NULLPTR));
        comboBox->clear();
        comboBox->insertItems(0, QStringList()
         << QApplication::translate("MainWindow", "Release", Q_NULLPTR)
         << QApplication::translate("MainWindow", "Beta", Q_NULLPTR)
        );
        checkBox->setText(QApplication::translate("MainWindow", "Use Protected Module", Q_NULLPTR));
        groupBox->setTitle(QApplication::translate("MainWindow", "Core Information", Q_NULLPTR));
        label_2->setText(QApplication::translate("MainWindow", "Forks", Q_NULLPTR));
        label_3->setText(QApplication::translate("MainWindow", "Stars", Q_NULLPTR));
        label_4->setText(QApplication::translate("MainWindow", "Last Updated:", Q_NULLPTR));
        groupBox_2->setTitle(QApplication::translate("MainWindow", "Launch World of Warcraft", Q_NULLPTR));
        wow86_bt->setText(QApplication::translate("MainWindow", "World of Warcraft (x86)", Q_NULLPTR));
        wow64_bt->setText(QApplication::translate("MainWindow", "World of Warcraft (x64)", Q_NULLPTR));
        wow_mac_bt->setText(QApplication::translate("MainWindow", "World of Warcraft (Mac)", Q_NULLPTR));
        groupBox_3->setTitle(QApplication::translate("MainWindow", "World of Warcraft Location:", Q_NULLPTR));
        browse_bt->setText(QApplication::translate("MainWindow", "Browse", Q_NULLPTR));
        toolbox_grp->setTitle(QApplication::translate("MainWindow", "ToolBox Info", Q_NULLPTR));
        label_5->setText(QApplication::translate("MainWindow", "Version", Q_NULLPTR));
        label_6->setText(QApplication::translate("MainWindow", "OS", Q_NULLPTR));
        tabWidget->setTabText(tabWidget->indexOf(core_tab), QApplication::translate("MainWindow", "Core", Q_NULLPTR));
        QTableWidgetItem *___qtablewidgetitem = cr_tb->horizontalHeaderItem(0);
        ___qtablewidgetitem->setText(QApplication::translate("MainWindow", "X", Q_NULLPTR));
        QTableWidgetItem *___qtablewidgetitem1 = cr_tb->horizontalHeaderItem(1);
        ___qtablewidgetitem1->setText(QApplication::translate("MainWindow", "Name", Q_NULLPTR));
        QTableWidgetItem *___qtablewidgetitem2 = cr_tb->horizontalHeaderItem(2);
        ___qtablewidgetitem2->setText(QApplication::translate("MainWindow", "Stars", Q_NULLPTR));
        QTableWidgetItem *___qtablewidgetitem3 = cr_tb->horizontalHeaderItem(3);
        ___qtablewidgetitem3->setText(QApplication::translate("MainWindow", "Description", Q_NULLPTR));
        QTableWidgetItem *___qtablewidgetitem4 = cr_tb->horizontalHeaderItem(4);
        ___qtablewidgetitem4->setText(QApplication::translate("MainWindow", "Last Update", Q_NULLPTR));
        tabWidget->setTabText(tabWidget->indexOf(cr_tab), QApplication::translate("MainWindow", "Combat Routines", Q_NULLPTR));
        QTableWidgetItem *___qtablewidgetitem5 = mod_tb->horizontalHeaderItem(0);
        ___qtablewidgetitem5->setText(QApplication::translate("MainWindow", "X", Q_NULLPTR));
        QTableWidgetItem *___qtablewidgetitem6 = mod_tb->horizontalHeaderItem(1);
        ___qtablewidgetitem6->setText(QApplication::translate("MainWindow", "Name", Q_NULLPTR));
        QTableWidgetItem *___qtablewidgetitem7 = mod_tb->horizontalHeaderItem(2);
        ___qtablewidgetitem7->setText(QApplication::translate("MainWindow", "Stars", Q_NULLPTR));
        QTableWidgetItem *___qtablewidgetitem8 = mod_tb->horizontalHeaderItem(3);
        ___qtablewidgetitem8->setText(QApplication::translate("MainWindow", "Description", Q_NULLPTR));
        QTableWidgetItem *___qtablewidgetitem9 = mod_tb->horizontalHeaderItem(4);
        ___qtablewidgetitem9->setText(QApplication::translate("MainWindow", "Last Update", Q_NULLPTR));
        tabWidget->setTabText(tabWidget->indexOf(modules_tab), QApplication::translate("MainWindow", "Modules", Q_NULLPTR));
        tabWidget->setTabText(tabWidget->indexOf(stg_tab), QApplication::translate("MainWindow", "Settings", Q_NULLPTR));
        tabWidget->setTabText(tabWidget->indexOf(log_tab), QApplication::translate("MainWindow", "Log", Q_NULLPTR));
        refresh_bt->setText(QString());
        install_bt->setText(QApplication::translate("MainWindow", "Install/Update", Q_NULLPTR));
    } // retranslateUi

};

namespace Ui {
    class MainWindow: public Ui_MainWindow {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_MAINWINDOW_H
