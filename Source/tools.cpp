#include <tools.h>
#include <QMessageBox>
#include <QProcess>
#include <QFileDialog>
#include <QObject>

void Tools::MsgBox(QString txt) {
    QMessageBox *msgBox = new QMessageBox(0);
    msgBox->setText(txt);
    msgBox->exec();
}

inline const char * const BoolToString(bool b)
{
  return b ? "true" : "false";
}

void Tools::launchApp(QString folder, QString file) {
    QString str = QDir::toNativeSeparators(folder + "/" + file);
    bool rsl = QProcess::startDetached(str);
    if (!rsl) {
        this->MsgBox("Failed to open:\n"+str);
    }
}

QString Tools::OpenExplorer(QString path) {
    QString dirLoc = QFileDialog::getExistingDirectory(0, QObject::tr("Open Directory"),
        path,
        QFileDialog::ShowDirsOnly | QFileDialog::DontResolveSymlinks);
    return QDir::toNativeSeparators(dirLoc);
}
